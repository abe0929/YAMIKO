using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceanLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private bool _blackout;
    public GameObject Panelfade;   //�t�F�[�h�p�l���̎擾

    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�

    private float alpha;           //�p�l����alpha�l�擾�ϐ�

    [SerializeField] bool fadeout = false;
    void Start()
    {
        if (_blackout == true || fadeout == true)
        {
            fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
            alpha = fadealpha.color.a;                 //�p�l����alpha�l���擾
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
