using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceanLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private bool _blackout;
    public GameObject Panelfade;   //フェードパネルの取得

    Image fadealpha;               //フェードパネルのイメージ取得変数

    private float alpha;           //パネルのalpha値取得変数

    [SerializeField] bool fadeout = false;
    void Start()
    {
        if (_blackout == true || fadeout == true)
        {
            fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
            alpha = fadealpha.color.a;                 //パネルのalpha値を取得
        }

    }
    private void FixedUpdate()
    {
        if (fadeout == true)
        {
            Panelfade.SetActive(true);
            alpha += 0.005f;
            fadealpha.color = new Color(0, 0, 0, alpha);
            if (alpha >= 1)
            {
                SceneManager.LoadScene(_sceneName);
            }
        }
    }

    public void OnClick()
    {
        if(_blackout == false)
        {
            SceneManager.LoadScene(_sceneName);
        }else
        {
            fadeout = true;
        }
    
    }
}
