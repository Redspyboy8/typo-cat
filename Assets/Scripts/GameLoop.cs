using System;
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
    
    // private Particles _particles;

    public int points = 0;

    private void awardPoints()
    {
        double basePoints = Math.Floor(textManager.wordLength * 1.5);
        points += (int)basePoints;
    }

    private void StartNewWord()
    {
        textManager.word = dictManager.GetRandomWord();
        textManager.ResetText();
    }
    void Start()
    {
        // _particles = GetComponent<Particles>();
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
                // _particles.spawnCorrectParticles();
                awardPoints();
                StartNewWord();
            }
            else
            {
                // _particles.spawnWrongParticles();
                Invoke(nameof(StartNewWord), 2f);
                textManager.isDone = false;
            }

        }
    }
}
