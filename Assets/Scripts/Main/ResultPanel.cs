using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] GameObject panel = default;
    [SerializeField] Text messageText = default;
    public ResultScore resultScore;
    public void ShowPanel(string word = "")
    {
        if (string.IsNullOrEmpty(word))
        {
            messageText.text = "じかんぎれ！";
        }
        else
        {
            messageText.text = "「"+word + "」...\n「ん」で終わっちゃった！";
        }
        panel.SetActive(true);
        resultScore.ResultsScore();
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(SoundManager.SE.Finish);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
