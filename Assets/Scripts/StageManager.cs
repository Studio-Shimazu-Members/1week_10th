using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public TextAsset stageFile;
    TileType[,] tileTable;
    public TileManager tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //LoadStageFromText();
        //  DebugTable();
        // Instantiate(tilePrefab);
        // CreateStage();


    }

    public void LoadStageFromText()
    {
        string[] lines = stageFile.text.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        int colums = 2;
        int rows = 2;

        tileTable = new TileType[colums, rows];
        for (int y = 0; y < rows; y++)
        {
            string[] values = lines[y].Split(new[] { ',' });
            for (int x = 0; x < colums; x++)
            {
                if (values[x] == "0")
                {
                    tileTable[x, y] = TileType.APPLE;
                }
                else if (values[x] == "1")
                {
                    tileTable[x, y] = TileType.GOLIRA;
                }
                else if (values[x] == "2")
                {
                    tileTable[x, y] = TileType.RAPPA;
                }
                else if (values[x] == "3")
                {
                    tileTable[x, y] = TileType.PANTSU;
                }


            }
        }
    }

    public void DebugTable()
    {
        for (int y = 0; y < 2; y++)
        {
            string debugText = "";
            for (int x = 0; x < 2; x++)
            {
                debugText += tileTable[x, y] + ", ";

            }
            Debug.Log(debugText);
        }
    }



    public void CreateStage()
    {
        Vector2 halfSize;
        float tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        halfSize.x = tileSize * tileTable.GetLength(1) / 2;
        halfSize.y = tileSize * tileTable.GetLength(0) / 2;


        for (int y = 0; y < tileTable.GetLength(1); y++)
        {
            for (int x = 0; x < tileTable.GetLength(0); x++)
            {
                TileManager tile = Instantiate(tilePrefab);
                Vector2Int position = new Vector2Int(x, y);
                tile.SetType(tileTable[x, y]);

                tile.transform.position = (Vector2)position * tileSize - halfSize;

            }
        }
    }


}
