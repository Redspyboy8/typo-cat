using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectParticles : MonoBehaviour
{

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(SpawnParticles());
        }
    }
    IEnumerator SpawnParticles()
    {
        for (int i = 0; i < 4; i++)
        {
            gameObject.GetComponent<ParticleSystem>().Emit(5);
            yield return new WaitForSeconds(0.2f);
        }
    }
}