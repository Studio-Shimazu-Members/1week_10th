
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileListEntity))]//拡張するクラスを指定
public class DatabaseSetter : Editor
{

    /// <summary>
    /// InspectorのGUIを更新
    /// </summary>
    public override void OnInspectorGUI()
    {
        TileListEntity database = target as TileListEntity;

        if (GUILayout.Button("Button"))
        {
            Debug.Log("ボタンを押した");
            // exampleScript.Load();

            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Image/images_size_32.png").OfType<Sprite>().ToArray();
            database.tileList.Clear();

            foreach (Sprite sprite in sprites)
            {
                Panel panel = new Panel();
                panel.sprite = sprite;
                panel.words.Add("test");
                database.tileList.Add(panel);
            }
        }
        base.OnInspectorGUI();

    }
}