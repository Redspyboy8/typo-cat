using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField]
    public CorrectParticles correctParticles;
    
    [SerializeField]
    public WrongParticles wrongParticles;
    // Start is called before the first frame update

    public void spawnCorrectParticles()
    {
        correctParticles.startCorrectParticles();
    }

    public void spawnWrongParticles()
    {
        wrongParticles.startWrongParticles();
    }
}
