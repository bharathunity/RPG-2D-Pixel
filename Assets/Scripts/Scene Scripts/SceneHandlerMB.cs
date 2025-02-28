using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game2D.Client
{
    public class SceneHandlerMB : MonoBehaviour
    {
        public enum Name
        {
            Start = 0,
            Game = 1
        }

        [SerializeField] Name m_ToSceneName;
        [SerializeField] Button m_SceneChange_Button;

        
        private void OnEnable()
        {
            m_SceneChange_Button.onClick.AddListener(ToScene);
        }

        private void OnDisable()
        {
            m_SceneChange_Button.onClick.RemoveListener(ToScene);
        }

        void ToScene()
        {
            Task.Delay(2000);
            SceneManager.LoadSceneAsync((int)m_ToSceneName);
        }

    }
}

