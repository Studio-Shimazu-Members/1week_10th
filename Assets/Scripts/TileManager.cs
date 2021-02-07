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

    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetType(TileType tileType)
    {
        type = tileType;
        SetImage(type);
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
       
            AfterCorrectFinishTile0();
       
    }

    public void AfterCorrectFinishTile0()
    {
        if (type == TileType.APPLE)
        {
            SetType(TileType.FINISH);
        }
        else if (type == TileType.GOLIRA)
        {
            SetType(TileType.FINISH);
        }
        else if (type == TileType.RAPPA)
        {
            SetType(TileType.FINISH);
        }
        else if (type == TileType.PANTSU)
        {
            SetType(TileType.FINISH);
        }

    }
}
