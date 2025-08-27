using System;
using UnityEngine;

public enum TileType
{
    Gray, //기본
    Blud, //점수 +10
    Red, //점수 -10
    Yellow, //점수 +- 20
    Green, //5초간 red에 대하여 무적
    Purple //순간이동
}
public class Tile : MonoBehaviour
{
    public TileType currentType;
    
    private SpriteRenderer sr;
    
    private Color basicColor = Color.gray;
    private Color plusColor = Color.blue;
    private Color minusColor = Color.red;

    private bool basicTile;
    private bool plusTile;
    private bool minusTile;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetTileType(TileType newType)
    {
        currentType = newType;

        switch (currentType)
        {
            case TileType.Gray:
                sr.color = Color.gray;
                break;
            case TileType.Blud:
                sr.color = Color.blue;
                break;
            case TileType.Red:
                sr.color = Color.red;
                break;
            case TileType.Yellow:
                sr.color = Color.yellow;
                break;
            case TileType.Green:
                sr.color = Color.green;
                break;
            case TileType.Purple:
                sr.color = Color.magenta;
                break;
        }
        {
            
        }
    }
}
