using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.Globalization;

public class PanelManager : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text downTime = default;
    [SerializeField] UnityEngine.UI.Text addScore = default;
    [SerializeField] Sprite hideSprite = default;
    [SerializeField] TileListEntity tileListEntity = default;
    // public const int PANEL_MAX = 20;
    [SerializeField] Transform panelParent = default;
    PanelCore[] panelCores;

    [SerializeField] MessagePanel messagePanel = default;
    [SerializeField] ResultPanel resultPanel = default;

    public ScoreManager scoreManager;
    public Timer timer;
    
    // 最後に選んだ文字
    string lastWord;
    string wrongAnswer = "ぜんぜんちがうよ！";

    // 人を入れるアイデア
    // ・データベースの0番を人にする
    // ・パネルをセットする際はデータベースの1番以上から設定する
    // ・最後のパネルに人（データベースの0番）をセットする（現状：りんご）


    private void Start()
    {
        Setup();
    
        messagePanel.UpdateMessage("「"+lastWord[lastWord.Length - 1] + "」ではじまるのは　どれだ？");
    }

    void Setup()
    {
        addScore.gameObject.SetActive(false);
        downTime.gameObject.SetActive(false);
        SoundManager.instance.PlayBGM(SoundManager.BGM.Main);
        resultPanel.HidePanel();
        lastWord = "しりとり";
        // 表示用のオブジェクトを取得
        panelCores = panelParent.GetComponentsInChildren<PanelCore>();
        // データベースからランダムにデータを取得
        Panel[] randomDataSet = GetRandomPanelDataSet(tileListEntity);
        // 反映
        SetPanels(randomDataSet);
        SetHumanPanel(tileListEntity.tileList[0]);
        timer.StartTime();
    }

    // データベースのデータ反映
    void SetPanels(Panel[] panels)
    {
        for (int i = 0; i < panelCores.Length; i++)
        {
            panelCores[i].SetPanel(panels[i]);
            panelCores[i].ClickAction = PanelClickAction;
        }
    }

    // 最後に人の配置
    void SetHumanPanel(Panel human)
    {
        int lastIndex = panelCores.Length - 1;
        panelCores[lastIndex].SetPanel(human);
        panelCores[lastIndex].ClickAction = PanelClickAction;
    }

    // データベースからランダムにデータを持ってくる
    Panel[] GetRandomPanelDataSet(TileListEntity database)
    {
        // データが壊れないようにコピーする
        List<Panel> databaseCopy = new List<Panel>(database.tileList);

        // 渡すデータを用意する
        Panel[] panels = new Panel[panelCores.Length];
        for (int i=0; i < panelCores.Length; i++)
        {
            // ランダムに選んで格納
            int r = UnityEngine.Random.Range(1, databaseCopy.Count); // データベースの0には人を入れるから1以上
            r = 1;
            panels[i] = databaseCopy[r];
            // 選んだものは除外
            databaseCopy.RemoveAt(r);
            if (databaseCopy.Count == 0)
            {
                break;
            }
        }
        return panels;
    }


    // ゲーム中の処理
    // パネルをクリックした時の処理：この関数をパネルに渡しておく
    public void PanelClickAction(PanelCore panelCore)
    {
        string nextWord = NextWord(panelCore.PanelData);
        Debug.Log(nextWord);
        if (string.IsNullOrEmpty(nextWord))
        {
            messagePanel.UpdateMessage(wrongAnswer);
            timer.Penalty(6);
            downTime.gameObject.SetActive(true);
            downTime.text = "-6";
            SoundManager.instance.PlaySE(SoundManager.SE.Wrong);
        }
        else if (nextWord.EndsWith("ん"))
        {
            Debug.Log("ゲームオーバー処理");
            panelCore.HidePanel(hideSprite);
            ShowResult();
            return;
        }
        else
        {
            lastWord = nextWord;
            panelCore.HidePanel(hideSprite);
            messagePanel.UpdateMessage(nextWord + "なのか！！");
            scoreManager.ScoreUp(lastWord.Length);
            addScore.gameObject.SetActive(true);
            addScore.text = "+"+lastWord.Length;
            SoundManager.instance.PlaySE(SoundManager.SE.Correct);
        }
        StartCoroutine(CorrectText());
    }

    IEnumerator CorrectText()
    {
        yield return new WaitForSeconds(1);
        addScore.gameObject.SetActive(false);
        downTime.gameObject.SetActive(false);
        messagePanel.UpdateMessage("「" + lastWord[lastWord.Length - 1] + "」ではじまるのは　どれだ？");
    }

    string NextWord(Panel panel)
    {
        // panelのwordsの中で一致するものを探す
        foreach(string word in panel.words)
        {
            //Word の頭文字、lastWord の最後の文字
            int result = CultureInfo.CurrentCulture.CompareInfo.IndexOf(word[0].ToString(), lastWord[lastWord.Length - 1].ToString(), CompareOptions.IgnoreNonSpace);
            if (result == 0)
            {
                return word;
            }
        }
        return "";
    }

    void ShowResult()
    {
        resultPanel.ShowPanel();
    }

    public void RankingShow()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(scoreManager.Score);
    }


}
