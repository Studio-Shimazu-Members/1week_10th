using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    [SerializeField] string nextScene = default;

    private void Start()
    {
        SoundManager.instance.StopBGM();
    }
    public void OnNewGameButton()
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Button);
        SceneManager.LoadScene(nextScene);
    }
}
