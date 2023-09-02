using UnityEngine;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine.Serialization;


public class GameData : MonoBehaviour
{
    public IntReactiveProperty LineNum => _lineNum;
    public string Name => _name;
    public string Talk => _talk;

    [SerializeField]
    [Header("現在の行数")]
    private IntReactiveProperty _lineNum;
    
    [SerializeField]
    [Header("名前")]
    private string _name;
    
    [SerializeField]
    [Header("台詞")]
    private string _talk;
    
    public void NextLine() => _lineNum.Value++;

    private void ChangeLine(int num) =>  _lineNum.Value = num;
    
}
