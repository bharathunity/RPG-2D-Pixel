using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Game2D.Client
{
    public class PlayTime : MonoBehaviour
    {

        [SerializeField] TMP_Text timer_TMPText;

        [SerializeField] float timeInMinutes = 0;
        [SerializeField] float timeInSeconds = 0;
        float timeDelta;


        // Update is called once per frame
        void Update()
        {
            UpdateTimer();
        }

        void UpdateTimer()
        {
            timeDelta += Time.deltaTime;
            if (timeDelta > 1)
            {
                timeDelta = 0;
                timeInSeconds += 1;
                if (timeInSeconds > 59)
                {
                    timeInMinutes += 1;
                    timeInSeconds = 0;
                }
            }
            timer_TMPText.text = $"{(int)timeInMinutes:D2}:{(int)timeInSeconds:D2}";
        }
    }
}

