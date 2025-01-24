using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2D.Client
{
    public class RightJoystickMB : MonoBehaviour
    {

        public static RightJoystickMB Instance;

        [field : SerializeField] public bool InUse { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// OnPointer Enter Event Trigger
        /// </summary>
        public void OnPointerTouch()
        {
            InUse = true;
        }

        /// <summary>
        /// OnPointer Exit Event Trigger
        /// </summary>
        public void OnPointerRemove()
        {
            InUse = false;
        }
    }

}
