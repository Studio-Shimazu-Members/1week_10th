using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // スコアの数値を管理
    // スコアの上昇機能
    // スコアUIの更新

    // 学習ポイント：プロパティってのを使えば、外部から取得できるけど設定はできない変数が作れるよ！（スコアの変更はこいつの仕事）
    public int Score { get; private set; }

    Text scoreText = default;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    // 初期化
    public void Init()
    {
        Score = 0;
        scoreText.text = "スコア:" + Score;
    }

    public void ScoreUp(int add)
    {
        Score += add;
        scoreText.text = "スコア:" + Score;
    }

    // デバッグ用
    // デバッグ用
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            ScoreUp("12345".Length);
        }
    }
}
