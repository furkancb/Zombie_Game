using UnityEngine;
using System.Collections;

public class HelicopterDoors : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        if (c.transform.root.tag == "Player")
        {
            GameManager.WinPlayer();
        }
    }
}