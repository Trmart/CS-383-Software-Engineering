using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_Walls : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            Game_Manager.Score(wallName);
            hitInfo.gameObject.SendMessage("ResetGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}