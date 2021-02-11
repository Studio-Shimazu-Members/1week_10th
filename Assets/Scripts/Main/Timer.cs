using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    const int TIME_MAX = 60;
    int countTime = TIME_MAX;

    Text timerText;
    // TODO:テスト用：本当はいらない
    [SerializeField] ResultPanel resultPanel = default;

    void Awake()
    {
        // 繰り返しGetComponentをするのはよくないので、最初に取得しておく
        timerText = GetComponent<Text>(); 
    }

    // 時間切れの場合に実行したい関数を登録する
    public UnityAction TimeUpAction;


    // カウントダウンを開始する
    public void StartTime()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        Debug.Log("CountDown");
        UpdateText(countTime);
        // 0より大きい場合は繰り返す
        while (countTime > 0)
        {
            // １秒処理を待機する
            yield return new WaitForSeconds(1);
            countTime--;
            UpdateText(countTime);
        }
        // TODO:テスト用：本当はいらない
        resultPanel.ShowPanel();


        TimeUpAction.Invoke();
    }

    public void ResetTime()
    {
        countTime = TIME_MAX;
        UpdateText(countTime);
    }

    public void Penalty(int downTime)
    {
        countTime -= downTime;
        if (countTime < 0)
        {
            countTime = 0;
        }
    }

    private void UpdateText(int time)
    {
        if (time < 0)
        {
            time = 0;
        }
        timerText.text = "じかん " + time.ToString("D2") + " 秒";
    }
}
