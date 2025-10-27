using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GameLoop : MonoBehaviour
{
    [FormerlySerializedAs("textProvider")] [SerializeField]
    private TextManager textManager;
    
    [FormerlySerializedAs("dictCreator")] [SerializeField]
    private DictManager dictManager;

    private void awardPoints() {}

    private void StartNewWord()
    {
        textManager.word = dictManager.GetRandomWord();
        textManager.ResetText();
    }
    void Start()
    {
        while (!dictManager.isLoaded) {}

        textManager.word = dictManager.GetRandomWord();
        textManager.ResetText();

    }

    // Update is called once per frame
    void Update()
    {
        if (textManager.isDone)
        {
            if (textManager.isCorrect)
            {
                awardPoints();
                StartNewWord();
            }
            else
            {
                Invoke(nameof(StartNewWord), 2f);
                textManager.isDone = false;
            }

        }
    }
}
