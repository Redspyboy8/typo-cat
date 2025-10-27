using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TextManager : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI tmPro_;

    [FormerlySerializedAs("points")] public int wordLength = 0;
    public bool isCorrect = true;
    
    [SerializeField]
    public string word = "";
    
    public bool isDone = false;
    
    private int _currentWordIndex = 0;
    private char _previousChar = '\n';
    List<int> incorrectChars = new List<int>();

    public void ResetText()
    {
        _currentWordIndex = 0;
        isDone = false;
        isCorrect = true;
        wordLength = word.Length;
        tmPro_.text = $"<color=\"orange\">{word.ToCharArray()[0]}</color>{word.Substring(1)}";
        incorrectChars.Clear();
        _previousChar = '\n';
    }
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
                if (firstChar != word.ToUpper()[_currentWordIndex] && firstChar != word.ToLower()[_currentWordIndex])
                {
                    incorrectChars.Add(_currentWordIndex);
                    char[] temp = word.ToCharArray();
                    temp[_currentWordIndex] = firstChar;
                    isCorrect = false;
                    wordLength = 0;
                    word = new string(temp);
                }
                UpdateTextOnInput();
                _currentWordIndex++;
            }

            if (_currentWordIndex == word.Length && !isDone)
            {
                isDone = true;
                UpdateTextOnCompletion();
            } 
        }
    }

    private void UpdateTextOnInput()
    {
        if (_currentWordIndex + 1 < word.Length)
        { 
            string highlightedText = word;
            string mdHighlight = "<color=\"orange\">";
            highlightedText = highlightedText.Insert(_currentWordIndex + 1, mdHighlight);
            highlightedText = highlightedText.Insert(_currentWordIndex + mdHighlight.Length + 2, "</color>");
            tmPro_.text = highlightedText;
        }

    }

    private void UpdateTextOnCompletion()
    {
        string highlightedText = "";
        char[] wordChars = word.ToCharArray();

        if (incorrectChars.Count == 0)
        {
            tmPro_.text = word;
        }
        else
        {
            const string correctHighlight = "<mark=#028a0faa>";
            const string incorrectHighlight = "<mark=#ff2400aa>";
            const string endMark = "</mark>";
            for (int i = 0; i < wordChars.Length; i++)
            {
                char nextChar = wordChars[i];
            
                if (incorrectChars.Contains(i))
                {
                    highlightedText += $"{incorrectHighlight}{nextChar}{endMark}";
                }
                else
                {
                    highlightedText += $"{correctHighlight}{nextChar}{endMark}";
                }
            }
            tmPro_.text = highlightedText;
        }
        
    }


    
    void Start()
    {
        ResetText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !isDone)
        {
            CheckInputOnUpdate();
        }

    }
    
    
}
