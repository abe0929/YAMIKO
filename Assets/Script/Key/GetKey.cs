using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour, Ikey
{
    public bool IsOpen => _isOpen;
    
    private int _openCount = 0;
    
    private bool _isOpen = false;

    public void Open()
    {
        _openCount++;
        Debug.Log($"{_openCount}回目");
        if (_openCount == 5)
        { 
            _isOpen = true;
            Debug.Log("鍵を開けた"); 
        }   
        
    }
}
