using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game2D.Client
{
    public class GameManagerMB : MonoBehaviour
    {

        public enum Level
        {
            one = 1,
            two
        }

        public enum Started
        {
            Yes,
            No
        }

        private CharacterFactory characterFactory;

        public static GameManagerMB Instance;

        [field : SerializeField] public Level GameLevel { get; private set; }
        [field : SerializeField] public Started GameStarted { get; private set; }

        private void Awake()
        {
            Instance = this;
            characterFactory = new CharacterFactory();
        }

        void Start()
        {
            OnLevelBegan();
            GameStarted = Started.Yes;
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void UpdatePlayerPoints(Character character)
        {
            PlayerMB.PlayerMBSignature?.Invoke();
        }

        public void OnLevelBegan()
        {
            GameSceneUiManagerMB.Instance.ToggleLevelInfoPanelCompleted_TMP(true, "FINISH THE ENEMIES");
        }

        public void OnLevelCompleted()
        {
            GameSceneUiManagerMB.Instance.ToggleLevelInfoPanel();
            GameSceneUiManagerMB.Instance.ToggleLevelInfoPanelCompleted_TMP(true, "FINISHED IN "+PlayTimeMB.Instance.m_Timer_TMPText.text + "s");
            GameSceneUiManagerMB.Instance.ToggleExitPanel();
        }

    }

}
