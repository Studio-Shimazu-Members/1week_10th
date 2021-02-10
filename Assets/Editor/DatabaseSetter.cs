using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileListEntity))]//拡張するクラスを指定
public class DatabaseSetter : Editor
{
    // 表示用とスコア要は分けたほうがいいのかな？（学校/がっこう　のように）
    List<List<string>> wordList = new List<List<string>>()
    {
        new List<string>(){"りんご", "あっぷる"},
        new List<string>(){"ごりら"},
        new List<string>(){"らっぱ"},
        new List<string>(){"ぱんつ"},
    };

    public override void OnInspectorGUI()
    {
        TileListEntity database = target as TileListEntity;

        if (GUILayout.Button("Button"))
        {
            // 画像データを取得
            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Image/images_size_32.png").OfType<Sprite>().ToArray();
            database.tileList.Clear();

            for(int i=0; i<sprites.Length; i++)
            {
                Panel panel = new Panel();
                panel.sprite = sprites[i];
                if (i < wordList.Count)
                {
                    panel.words = wordList[i];
                }
                else
                {
                    panel.words.Add("ななし");
                }
                database.tileList.Add(panel);
            }
        }
        base.OnInspectorGUI();

    }
}