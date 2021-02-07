using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}
