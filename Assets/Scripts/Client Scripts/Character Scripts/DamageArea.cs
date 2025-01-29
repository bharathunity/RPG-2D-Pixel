using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game2D.Client
{
    public class DamageArea : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Enemy")
            {
                Debug.Log("Enemy is detected inside the Damage Area!");
            }
        }
    }

}
