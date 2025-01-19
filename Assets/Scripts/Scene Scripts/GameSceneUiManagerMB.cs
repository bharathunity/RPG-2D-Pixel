using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game2D.Client
{
    public class GameSceneUiManagerMB : MonoBehaviour
    {

        public static GameSceneUiManagerMB  Instance;

        [SerializeField] FingerSwipeDetectionMB m_FingerSwipeDetectionMB;
        [SerializeField] Button                 m_Hamburger_Button;
        [SerializeField] Transform              m_ExitPanel;
        [SerializeField] Transform              m_RightJoystick;

        #region Monobehaviour callbacks

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }
            Instance = this;
        }


        private void OnEnable()
        {
            m_Hamburger_Button.onClick.AddListener(ToggleExitPanel);
        }

        private void OnDisable()
        {
            m_Hamburger_Button.onClick.RemoveListener(ToggleExitPanel);
        }

        // Start is called before the first frame update
        void Start()
        {

        }
        #endregion

        #region Public Methods
        public void ToggleExitPanel()
        {
            bool value = m_ExitPanel.gameObject.activeInHierarchy;
            switch (value)
            {
                case true:
                    m_ExitPanel.gameObject.SetActive(false);
                    GameSceneManagerMB.Instance.ResumeGame();
                    break;
                case false:
                    m_ExitPanel.gameObject.SetActive(true);
                    GameSceneManagerMB.Instance.PauseGame();
                    break;
            }
            
        }

        public void ToggleRightJoyStick(bool value)
        {
            m_RightJoystick.gameObject.SetActive(value);
        }

        public void ToggleFingerSwipePanel_Script(bool value)
        {
            m_FingerSwipeDetectionMB.gameObject.SetActive(value);
        }
        #endregion

    }
}

