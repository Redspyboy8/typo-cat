using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectArrows : MonoBehaviour
{
    public void spawnCorrectParticles()
    {
        StartCoroutine(SpawnParticles());
    }
    IEnumerator SpawnParticles()
    {
        for (int i = 0; i < 2; i++)
        {
            gameObject.GetComponent<ParticleSystem>().Emit(3);
            yield return new WaitForSeconds(0.2f);
        }
    }
}