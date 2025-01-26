using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Game2D.Client
{
    public class PlayTimeMB : MonoBehaviour
    {

        [field : SerializeField] public TMP_Text m_Timer_TMPText { get; private set; }
        [field : SerializeField] public float Minutes { get; private set; }
        [field : SerializeField] public float Seconds { get; private set; }

        float timeDelta;

        public static PlayTimeMB Instance;


        private void Awake()
        {
            Instance = this;
        }

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
                Seconds += 1;
                if (Seconds > 59)
                {
                    Minutes += 1;
                    Seconds = 0;
                }
            }
            m_Timer_TMPText.text = $"{(int)Minutes:D2}:{(int)Seconds:D2}";
        }
    }
}

