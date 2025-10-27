using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongParticles : MonoBehaviour
{
    public void startWrongParticles()
    {
        StartCoroutine(SpawnParticles());

    }
    IEnumerator SpawnParticles()
    {
        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<ParticleSystem>().Emit(3);
            yield return new WaitForSeconds(0.14f);
        }
    }
}