using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextProvider : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI tmPro_;
    
    [SerializeField]
    // private 
    
    public string word = "SAMPLE";
    private string formattedWord;
    private int _currentWordIndex = 0;
    private char _previousChar = '\n';
    private bool isDone = false;
    List<int> incorrectChars = new List<int>();

    private void CheckInputOnUpdate()
    {
        string inputString = Input.inputString;
        if (inputString != "") {
            char firstChar = inputString[0];
            if (firstChar == _previousChar)
            {
                _previousChar = '\n';
                return;
            }
            if (_currentWordIndex < word.Length)
            {
                if (firstChar != word[_currentWordIndex])
                {
                    incorrectChars.Add(_currentWordIndex);
                    char[] temp = word.ToCharArray();
                    temp[_currentWordIndex] = firstChar;
                    word = new string(temp);
                }
                UpdateText();
                _currentWordIndex++;
            }

            if (_currentWordIndex == word.Length)
            {
                isDone = true;
            }
        }
    }

    private void UpdateText()
    {
        string highlightedText = word;
        string mdHighlight = "<color=\"orange\">";
        highlightedText = highlightedText.Insert(_currentWordIndex, mdHighlight);
        highlightedText = highlightedText.Insert(_currentWordIndex + mdHighlight.Length + 1, "</color>");
        tmPro_.text = highlightedText;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            CheckInputOnUpdate();
        }

    }
    
    
}
