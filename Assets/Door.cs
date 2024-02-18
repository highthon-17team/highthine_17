using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Player)
        {
            Player.transform.position = new Vector3(65, -14, 0);
        }
    }
}
