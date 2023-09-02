using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Ikey
{
    int _openCount = 0;
    
    public void Open()
    {
        _openCount++;
        Debug.Log($"{_openCount}回目");
        if (_openCount == 5)
        {
            Debug.Log("鍵を開けた");
        }
    }
}
