using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Game2D.Client
{
    public class FingerSwipeDetectionMB : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] float swipeThreshold = 50f;

        Vector2 _initialXposition;

        /// <summary>
        /// 1  -> Right swipe
        /// -1 -> Left swipe
        /// </summary>
        public static int SwipingDirection {  get; private set; }
        
        void Start()
        {

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _initialXposition = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            DetectSwipe(eventData.position);
        }

        private void DetectSwipe(Vector2 currentPosition)
        {
            float horizontalDiff = currentPosition.x - _initialXposition.x;

            if (Mathf.Abs(horizontalDiff) > swipeThreshold)
            {
                if (horizontalDiff > 0)
                {
                    // Debug.Log("Swipe Right Detected");
                    SwipingDirection = 1;
                }
                else
                {
                    // Debug.Log("Swipe Left Detected");
                    SwipingDirection = -1;
                }
            }
            
        }
    }
}

