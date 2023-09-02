using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Ikey
{
    [SerializeField]
    private KeyType _key;
    
    private int _openCount = 0;
    
    private enum KeyType
    {
        ExitKey,
        HomeEconomicsRoomKey,
        MusicRoomKey
    }
    
    public void Open()
    {
        if (_key == KeyType.ExitKey)
        {
            _openCount++;
            Debug.Log($"{_openCount}回目");
            if (_openCount == 5)
            {
                Debug.Log("鍵を開けた");
            }   
        }
    }
}
