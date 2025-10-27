using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimpleJSON;
using UnityEngine;


public class DictManager : MonoBehaviour
{
    private List<string> _all_words = new List<string>();
    public bool isLoaded = false; 

    // public Dictionary<int, List<string>> AllDicts = new Dictionary<int, List<string>>();
    // Start is called before the first frame update

    public string GetRandomWord()
    {
        return _all_words[Random.Range(0, _all_words.Count)];
    }
    
    void Start()
    {
        string rootPath = Application.dataPath + "/Text";
        var sr = new StreamReader($"{rootPath}/word_dictionary_all.txt");
        string fileContents =  sr.ReadToEnd();
        sr.Close();
        fileContents = fileContents.Substring(1, fileContents.Length - 2);
        fileContents = fileContents.Replace("\"", "");
        fileContents = fileContents.Replace(" ", "");
        _all_words = fileContents.Split(",").ToList();
        isLoaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
