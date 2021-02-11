using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] GameObject panel = default;
    public GameManager gameManager;
    public SoundManager soundManager;

    public ResultScore resultScore;
    public void ShowPanel()
    {
        panel.SetActive(true);
        resultScore.ResultsScore();
        soundManager.StopBGM();
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
