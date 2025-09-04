using System;
using UnityEngine;

public enum TileType
{
    Gray, //기본
    Green, //점수 +10
    Red, //점수 -10
    Yellow, //점수 +- 20
    Blue, //5초간 red에 대하여 무적
    Purple //순간이동
}
public class Tile : MonoBehaviour
{
    public TileType currentType;
    
    private SpriteRenderer sr;
  
    private bool basicTile;
    private bool plusTile;
    private bool minusTile;
    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    private void OnMouseDown()  // 마우스로 클릭했을 때 실행
    {
        // 타입을 순환시킴
        currentType = (TileType)(((int)currentType + 1) % System.Enum.GetValues(typeof(TileType)).Length);
        SetTileType(currentType);
    }
    
    public void SetTileType(TileType newType)
    {
        currentType = newType;

        switch (currentType)
        {
            case TileType.Gray:
                sr.color = Color.gray;
                break;
            case TileType.Green:
                sr.color = Color.green;
                break;
            case TileType.Red:
                sr.color = Color.red;
                break;
            case TileType.Yellow:
                sr.color = Color.yellow;
                break;
            case TileType.Blue:
                sr.color = Color.blue;
                break;
            case TileType.Purple:
                sr.color = Color.magenta;
                break;
        }
    }
}
