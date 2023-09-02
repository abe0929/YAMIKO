using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UniRx;

public class GSSManager : MonoBehaviour
{
    public string[][] Datas => _datas;

    [SerializeField]
    private string _sheetID = "読み込むシートのID";
    [SerializeField]
    private string _sheetName = "読み込むシート";

    private bool _isLoading;
    
    [SerializeField]
    private string[][] _datas;
    
    private void Awake()
    {
        StartCoroutine(GetFromWeb());
    }

    /// <summary>GSS(グーグルスプレッドシート)を読み込む</summary>
    /// <returns></returns>
    private IEnumerator GetFromWeb()
    {
        _isLoading = true;
        var url = "https://docs.google.com/spreadsheets/d/" + _sheetID + "/gviz/tq?tqx=out:csv&sheet=" + _sheetName;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        _isLoading = false;

        var protocol_error = request.result == UnityWebRequest.Result.ProtocolError ? true : false;
        var connection_error = request.result == UnityWebRequest.Result.ConnectionError ? true : false;
        
        if (protocol_error || connection_error)
        {
            Debug.LogError(request.error);
        }
        else
        {
            _datas = ConvertGSStoJaggedArray(request.downloadHandler.text);
        }
    }
    
    /// <summary>読み込んだGSSをstring化</summary>
    /// <param name="text">GSSデータ</param>
    /// <returns></returns>
    private string[][] ConvertGSStoJaggedArray(string text)
    {
        var reader = new StringReader(text);
        var rows = new List<string[]>();
        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine();        // 一行ずつ読み込み
            var elements = line.Split(',');    // 行のセルは,で区切られる
            for (var i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            rows.Add(elements);
        }
        return rows.ToArray();
    }
}
