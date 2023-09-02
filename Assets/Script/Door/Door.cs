using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("ゲットキー")]
    private GetKey _getKey;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("反応はしてる");
        if (other.tag == "Player")
        {
            if (_getKey.IsOpen)
            {
                Debug.Log("脱出");
            }
        }
    }
}