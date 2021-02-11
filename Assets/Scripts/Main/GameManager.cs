using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // staticを使う:どこからでも使えるもの
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int aaaa = 100;
    [SerializeField] Text textQuestion;
    public TileManager tileManager;
    public StageManager stageManger;
    public  int answer;
    public Timer timer;
    public ScoreManager scoreManager;

    string lastWord;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Main);
     //   string aa = "りんご";
      //  Debug.Log(aa[0]);
      //  Debug.Log(aa[aa.Length-1]);
      //  lastWord = "りんご";

        stageManger.LoadStageFromText();
        stageManger.DebugTable();
       // Instantiate(tilePrefab);
        stageManger.CreateStage();
        answer = 0;
        timer.StartTime();
    }


    private void Update()
    {
       
        //TextController();
    }
    public void OnClick(TileManager tile)
    {
        string comWord = "ごりら";
        if (lastWord[lastWord.Length-1] == comWord[0])
        {

        }
        Debug.Log(tile.type);
    }

    void AIAction()
    {
        TileManager tile = GetMatchTile();
    }

    TileManager GetMatchTile()
    {
        // 2,2の全てのタイルで、lastWord[lastWord.Length-1]と一致するタイルを探したい
        for (int i = 0; i < stageManger.tiles.GetLength(0); i++)
        {
            for (int j = 0; j < stageManger.tiles.GetLength(1); j++)
            {
                TileManager tile = stageManger.tiles[i, j];
                string matchWord = tile.words.Find(word => word[0] == lastWord[lastWord.Length - 1]);

                // 一致したら:何か言葉が入ったら
                if (string.IsNullOrEmpty(matchWord) == false)
                {
                    // タイルを
                    return tile;
                }
            }
        }
        return null;
    }

    public void LoadScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    public void RankingScene()
    {
        SceneManager.LoadScene("Ranking");
    }

}
