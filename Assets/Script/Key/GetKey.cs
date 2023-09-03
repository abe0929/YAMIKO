using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour, Ikey
{
    public bool IsOpen => _isOpen;
    
    [SerializeField]
    [Header("何回取ったら解除するか")]
    private int _openCount = 5;
    
    private int _unlockCount;
    
    private bool _isOpen = false;

    public void Open()
    {
        _unlockCount++;
        Debug.Log($"{_unlockCount}回目");
        if (_unlockCount == _openCount)
        { 
            _isOpen = true;
            Debug.Log("鍵を開けた"); 
        }   
        
    }
}
