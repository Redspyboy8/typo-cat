using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class SimpleTimer : MonoBehaviour
    {
        public float targetTime = 60.0f; 
        bool isActive = false;

        void Update()
        {
            if (isActive)
            { 
                targetTime -= Time.deltaTime; 
                if (targetTime <= 0.0f) { timerEnded(); } 
            }

        }

        void timerEnded()
        {
            
        }
    }
