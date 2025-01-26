
using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace Game2D.Client
{
    public class GameSceneUiManagerMB : MonoBehaviour
    {

        public static GameSceneUiManagerMB  Instance;

        [SerializeField] FingerSwipeDetectionMB m_FingerSwipeDetectionMB;
        [SerializeField] Button                 m_Profile_Button;
        [SerializeField] Transform              m_ExitPanel;
        [SerializeField] Transform              m_RightJoystick;
        [SerializeField] Transform              m_LevelInfoPanel;
        [SerializeField] Transform              m_LevelInfoPanelCompleted_TMP;
        [SerializeField] Transform              m_Reward_Image;
        

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
            m_Profile_Button.onClick.AddListener(ToggleExitPanel);
        }

        private void OnDisable()
        {
            m_Profile_Button.onClick.RemoveListener(ToggleExitPanel);
        }

        // Start is called before the first frame update
        void Start()
        {
            Invoke(nameof(ToggleLevelInfoPanel), 2);
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
                    //GameManagerMB.Instance.ResumeGame();
                    break;
                case false:
                    m_ExitPanel.gameObject.SetActive(true);
                    //GameManagerMB.Instance.PauseGame();
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

        public void ToggleLevelInfoPanel()
        {
            switch (m_LevelInfoPanel.gameObject.activeInHierarchy)
            {
                case true:
                    m_LevelInfoPanel.gameObject.SetActive(false);
                    break;
                case false:
                    m_LevelInfoPanel.gameObject.SetActive(true);
                    break;   
            }
        }

        public void ToggleLevelInfoPanelCompleted_TMP(bool value, string output)
        {
            m_LevelInfoPanelCompleted_TMP.gameObject.SetActive(value);
            m_LevelInfoPanelCompleted_TMP.GetComponent<TMP_Text>().text = output;
            // m_Reward_Image.gameObject.SetActive(value);
        }
        #endregion

    }
}

