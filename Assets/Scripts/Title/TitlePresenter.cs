using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitlePresenter : MonoBehaviour
{

    public void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Title);
    }

    public void OnNewGameButton()
    {
        SceneManager.LoadScene("Main");
    }

}
