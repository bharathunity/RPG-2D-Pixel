using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Game2D.Client
{
    public class PlayerDataInfoUiMB : MonoBehaviour
    {

        public static PlayerDataInfoUiMB Instance;

        [SerializeField] Slider     m_PlayerHealth_Slider;
        [SerializeField] TMP_Text   m_Enemy1KillCount_Text;

        #region Monobehaviour callbacks
        private void Awake()
        {
            Instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {

        }
        #endregion

        public void UpdateEnemy1KillCount_Text(int value)
        {
            m_Enemy1KillCount_Text.text = $"{value:D2}";
        }

        public void UpdatePlayerSlider(float value)
        {
            m_PlayerHealth_Slider.value = value;
        }



    }
}

