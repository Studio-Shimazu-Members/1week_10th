using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitlePresenter : MonoBehaviour
{
    [SerializeField] string nextScene = default;
    public void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Title);
    }

    public void OnNewGameButton()
    {
        SceneManager.LoadScene(nextScene);
    }

}
