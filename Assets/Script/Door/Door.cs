using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("ゲットキー")]
    private GetKey _getKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_getKey.IsOpen)
            {
                SceneManager.LoadScene("GameClear");
            }
        }
    }
}