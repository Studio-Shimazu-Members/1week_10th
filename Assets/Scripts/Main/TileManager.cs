using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    APPLE,
    GOLIRA,
    RAPPA,
    PANTSU,
    FINISH,

}

public class TileManager : MonoBehaviour
{
    public TileType type;
    public Sprite appleSprite;
    public Sprite goliraSprite;
    public Sprite rappaSprite;
    public Sprite pantsuSprite;
    public Sprite finishSprite;

    public List<string> words = new List<string>();

    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        // GameManagerの関数を使う
       // Debug.Log(GameManager.instance.aaaa);
       // GameManager.instance.OnClick(this);
       
      //  this.type = TileType.APPLE;
     //   this.appleSprite = null;

        // GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // オブジェクトの取得方法
        // ・public か　[SerializeField]
        // ・static
        // ・GameObject.Find("")// ヒエラルキーから探してくる
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetType(TileType tileType)
    {
        type = tileType;
        SetImage(type);
        // データベースからデータを引っ張ってきて、設定する
    }


    void SetImage(TileType type)
    {
        if (type == TileType.APPLE)
        {
            spriteRenderer.sprite = appleSprite;
        }
        else if (type == TileType.GOLIRA)
        {
            spriteRenderer.sprite = goliraSprite;
        }
        else if (type == TileType.RAPPA)
        {
            spriteRenderer.sprite = rappaSprite;
        }
        else if (type == TileType.PANTSU)
        {
            spriteRenderer.sprite = pantsuSprite;
        }
        else if (type == TileType.FINISH)
        {
            spriteRenderer.sprite = finishSprite;
        }

    }

    //クリックしたら実行

    public void OnTile()
    {
       if(GameManager.instance.answer == 0)
        {
            AfterCorrectFinishTile0();
        }
       else if (GameManager.instance.answer == 1)
        {
            AfterCorrectFinishTile1();
        }
        else if (GameManager.instance.answer == 2)
        {
            AfterCorrectFinishTile2();
        }
        else if (GameManager.instance.answer == 3)
        {
            AfterCorrectFinishTile3();
        }
    }

    public void AfterCorrectFinishTile0()
    {
        Debug.Log("no.0");
        if (type == TileType.APPLE)
        {
            SetType(TileType.FINISH);
           GameManager.instance.answer = 1;
        }
        else if (type == TileType.GOLIRA)
        {
            SetType(TileType.GOLIRA);
        }
        else if (type == TileType.RAPPA)
        {
            SetType(TileType.RAPPA);
        }
        else if (type == TileType.PANTSU)
        {
            SetType(TileType.PANTSU);
        }

    }


    public void AfterCorrectFinishTile1()
    {
        Debug.Log("no.1");

        if (type == TileType.GOLIRA)
        {
            SetType(TileType.FINISH);
            GameManager.instance.answer += 1;
        }
        else if (type == TileType.RAPPA)
        {
            SetType(TileType.RAPPA);
        }
        else if (type == TileType.PANTSU)
        {
            SetType(TileType.PANTSU);
        }

    }


    public void AfterCorrectFinishTile2()
    {
        Debug.Log("no.2");
        if (type == TileType.RAPPA)
        {
            SetType(TileType.FINISH);
            GameManager.instance.answer += 1;
        }
        else if (type == TileType.PANTSU)
        {
            SetType(TileType.PANTSU);
        }

    }

    public void AfterCorrectFinishTile3()
    {
        Debug.Log("no.3");
       if (type == TileType.PANTSU)
        {
            SetType(TileType.FINISH);
            GameManager.instance.answer += 1;
        }

    }
}
