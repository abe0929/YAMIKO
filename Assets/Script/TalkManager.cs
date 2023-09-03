using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Serialization;

public class TalkManager : MonoBehaviour
{
    public bool IsPlaying => _isPlaying;

    /// <summary>喋っている人の名前</summary>
    [SerializeField] 
    [Header("喋っている人の名前")]
    private Text _nameText = null;

    /// <summary>喋っている内容やナレーション</summary>
    [SerializeField]
    [Header("喋っている内容やナレーション")]
    private Text _talkText = null;

    [SerializeField] 
    [Header("テキストが再生しているか")]
    private bool _isPlaying = false;

    /// <summary>テキストの表示速度</summary>
    [SerializeField]
    [Header("テキストの表示速度")] 
    private float textSpeed = 0.1f;

    [SerializeField] 
    private GSSManager _gssManager;

    [SerializeField]
    private GameData _gameData;

    [SerializeField]
    private GameObject _yamiko;

    [SerializeField]
    private GameObject[] _text;

    private const int NAME_LINE = 0;
    private const int TALK_LINE = 1;

    private async void Start()
    {
        // this.UpdateAsObservable()
        //     .Subscribe(_ => Next())
        //     .AddTo(this);

        _gameData.LineNum
            .Skip(1)
            .Subscribe(CoText).AddTo(this);

        await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
        CoText(_gameData.LineNum.Value);
    }
    
    /// <summary>GSSを上から一行ずつ出力</summary>
    private async void CoText(int value)
    {
        var data = _gssManager.Datas;
        if (data.Length == value)
        {
            DrawText("", "");
            _yamiko.SetActive(true);
            _text[0].SetActive(false);
            _text[1].SetActive(false);
        }
        Debug.Log($"現在：{value}行");
        DrawText(data[value][NAME_LINE], data[value][TALK_LINE]);
        await Skip();
        _gameData.NextLine();
    }

    /// <summary>GSSの名前とセリフをテキストに反映</summary>
    private void DrawText(string name, string text)
    {
        _nameText.text = name;
        StartCoroutine(CoDrawText(text));
        //_talkText.text = text;
    }
    
    private void Next()
    {
        if (IsClicked())
            _gameData.NextLine();
    }

    /// <summary>テキストがヌルヌル出てくるためのコルーチン</summary>
    IEnumerator CoDrawText(string text)
    {
        _isPlaying = true;
        float time = 0;
    
        while (true)
        {
            yield return null;
            time += Time.deltaTime;
    
            if (IsClicked()) break;
    
            int len = Mathf.FloorToInt(time / textSpeed);
            if (len > text.Length) break;
            _talkText.text = text.Substring(0, len);
        }
    
        _talkText.text = text;
        yield return null;
        _isPlaying = false;
    }
    
    private bool IsClicked()
    {
        return Input.GetMouseButtonDown(0);
    }

    /// <summary>クリックされると一気に表示</summary>
    private IEnumerator Skip()
    {
        while (_isPlaying)
        {
            yield return null;
        }
    
        while (!IsClicked())
        {
            yield return null;
        }
    }
}
