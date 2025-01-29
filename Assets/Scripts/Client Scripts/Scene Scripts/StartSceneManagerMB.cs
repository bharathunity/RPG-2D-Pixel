using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D.Client
{
    public class StartSceneManagerMB : MonoBehaviour
    {
        [SerializeField] Animator m_Animator;

        private const string swordSwingAnimationName = "SwordShining";

        // Start is called before the first frame update
        void Start()
        {
            try
            {
                m_Animator.Play(swordSwingAnimationName);
            }
            catch(ArgumentException arg)
            {
                Debug.LogError(arg);
            }
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

