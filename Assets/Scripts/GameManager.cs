using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public TileManager tileManager;
    public StageManager stageManger;
    int answer;

    // Start is called before the first frame update
    void Start()
    {
        stageManger.LoadStageFromText();
        stageManger.DebugTable();
        //Instantiate(tilePrefab);
        stageManger.CreateStage();
        answer = 0;
    }

    public void OnClick(TileManager tile)
    {
        Debug.Log(tile.type);
    }
}
