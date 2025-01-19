using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game2D.Client
{
    public class GameSceneManagerMB : MonoBehaviour
    {

        CharacterFactory characterFactory;

        public static GameSceneManagerMB Instance;

        private void Awake()
        {
            characterFactory = new CharacterFactory();
            Instance = this;
        }

        void Start()
        {

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

    }

}
