using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] TileListEntity tileListEntity = default;
    // public const int PANEL_MAX = 20;
    [SerializeField] Transform panelParent = default;
    PanelCore[] panelCores;

    // 最後に選んだ文字
    string lastWord;

    private void Start()
    {
        lastWord = "しりとり";
        // Random.InitState(3);
        // 表示用のオブジェクトを取得
        panelCores = panelParent.GetComponentsInChildren<PanelCore>();
        // データベースからランダムにデータを取得
        Panel[] randomDataSet = GetRandomPanelDataSet(tileListEntity);
        // 反映
        SetPanels(randomDataSet);
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
            int r = Random.Range(0, databaseCopy.Count);
            r = 0;
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
    public void PanelClickAction(Panel panel)
    {
        string nextWord = NextWord(panel);
        if (string.IsNullOrEmpty(nextWord))
        {
            Debug.Log("NG");
        }
        else
        {
            Debug.Log("正解！"+ nextWord);
            lastWord = nextWord;
        }
    }

    string NextWord(Panel panel)
    {
        // panelのwordsの中で一致するものを探す
        foreach(string word in panel.words)
        {
            Debug.Log(word);

            if (word[0] == lastWord[lastWord.Length - 1])
            {
                return word;
            } 
        }
        return "";
    }
}
