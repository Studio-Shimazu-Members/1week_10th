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
        // 人
        new List<string>(){        
            "あべ","いのうえ","うぽつ","えさき","おがわ",
            "かせだ","きたじま","くまだ","けんたろう","こいずみ",
            "さとう","じょに","すらいもも","せきぐち","そね",
            "たに","ちょうの","つちや","てづか","とづか",
            "ななまる","にしだ","ぬまた","ねぎし","ののむら",
            "はとやま","ひむら","ふじき","へんみ","ほしの",
            "まえだ","みっちぇる","むろい","めぐれ","ももどり",
            "やだ","ゆかわ","よしだ",
            "らどくりふ","りょうつ","るる","れんほう","ろばーと",
            "わたなべ"
        },
        new List<string>(){"ごりら","さる",},
        new List<string>(){"びーる"},
        new List<string>(){"だんご"},
        new List<string>(){"どーなっつ"},
        new List<string>(){"ふえ"},
        new List<string>(){"ぱとか"},
        new List<string>(){"ぼうし"},
        new List<string>(){"とけい"},
        new List<string>(){"やま"},
        new List<string>(){"らっぱ"},
        new List<string>(){"ぱんつ"},
        new List<string>(){"けーき"},
        new List<string>(){"でんきゅう"},
        new List<string>(){"えびふらい"},
        new List<string>(){"ふね"},
        new List<string>(){"ぱそこん"},
        new List<string>(){"たいこ"},
        new List<string>(){"とり"},
        new List<string>(){"ゆきだるま"},
        new List<string>(){"かめら"},
        new List<string>(){"こーら"},
        new List<string>(){"こーひ"},
        new List<string>(){"ほうせき"},
        new List<string>(){"えんぴつ"},
        new List<string>(){"あいす"},
        new List<string>(){"じゅう"},
        new List<string>(){"すいか"},
        new List<string>(){"とらっく"},
        new List<string>(){"つり"},
        new List<string>(){"ふぉーく"},
        new List<string>(){"げーむき"},
        new List<string>(){"ごはん"},
        new List<string>(){"ぎたー"},
        new List<string>(){"はな"},
        new List<string>(){"いえ"},
        new List<string>(){"かいちゅうでんとう"},
        new List<string>(){"すし"},
        new List<string>(){"でんしゃ"},
        new List<string>(){"らじお"},
        new List<string>(){"へりこぷた"},
        new List<string>(){"ひこうき"},
        new List<string>(){"はっぱ"},
        new List<string>(){"はち"},
        new List<string>(){"ほん"},
        new List<string>(){"いか"},
        new List<string>(){"りぼん"},
        new List<string>(){"たけ"},
        new List<string>(){"つぼ"},
        new List<string>(){"くちべに"},
        new List<string>(){"おの"},
        new List<string>(){"しま"},
        new List<string>(){"じてんしや"},
        new List<string>(){"かぶとむし"},
        new List<string>(){"きのこ"},
        new List<string>(){"くま"},
        new List<string>(){"ねっくれす"},
        new List<string>(){"たまご"},
        new List<string>(){"つき"},
        new List<string>(){"こんびに"},
        new List<string>(){"くるま"},
        new List<string>(){"はんばーが"},
        new List<string>(){"めがね"},
        new List<string>(){"てれび"},
        new List<string>(){"じょうぎ"},
        new List<string>(){"ねこ"},
        new List<string>(){"さいころ"},
        new List<string>(){"てるてるぼうず"},
        new List<string>(){"ちょうちよ"},
        new List<string>(){"へび"},
        new List<string>(){"ねずみ"},
        new List<string>(){"ほうひょう"},
        new List<string>(){"にんじん"},
        new List<string>(){"のりまき"},
        new List<string>(){"おばけ"},
        new List<string>(){"おにぎり"},
        new List<string>(){"さかな"},
        new List<string>(){"といれっとぺーぱ"},
        new List<string>(){"ゆうほう"},
        new List<string>(){"かに"},
        new List<string>(){"ふで"},
        new List<string>(){"りんご"},
        new List<string>(){"おうかん","かんむり"},
        new List<string>(){"たいよう"},
        new List<string>(){"がいこつ"},
        new List<string>(){"なわ"},
        new List<string>(){"きりかぶ"},
        new List<string>(){"がっこう"},
        new List<string>(){"まいく"},
        new List<string>(){"ぶた"},
        new List<string>(){"しゃつ"},
        new List<string>(){"おかね"},
        new List<string>(){"にく"},
        new List<string>(){"かさ"},
        new List<string>(){"ろうそく"},
        new List<string>(){"くすり"},
        new List<string>(){"ぱん"},
        new List<string>(){"や"},
        new List<string>(){"ますく","ころな"},
        new List<string>(){"ぼーる"},
        new List<string>(){"かばん"},
        new List<string>(){"かたつむり"},
    };

    public override void OnInspectorGUI()
    {
        TileListEntity database = target as TileListEntity;
        if (GUILayout.Button("Button"))
        {
            // 画像データを取得
            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Image/images_size_32.png").OfType<Sprite>().ToArray();
            database.tileList.Clear();

            for (int i=0; i<sprites.Length; i++)
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
        EditorUtility.SetDirty(target);

    }
}