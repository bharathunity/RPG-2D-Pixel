using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D.Client
{
    public class InputControllerMB : MonoBehaviour
    {

        public static InputControllerMB Instance;
        /// <summary>
        /// Input Controller New Input Action
        /// </summary>
        internal InputController Input_Controller { get; private set; }
        private void Awake()
        {
            if (Instance != null) {
                Destroy(Instance);
            }
            Instance = this;
            Input_Controller = new InputController();
        }

        private void OnEnable()
        {
            Input_Controller?.Enable();
        }

        private void OnDisable()
        {
            Input_Controller?.Disable();
        }

        void Start()
        {

        }


        void Update()
        {

        }
    }

}
