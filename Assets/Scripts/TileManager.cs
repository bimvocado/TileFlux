using System;
using Unity.VisualScripting;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile tilePrefab;
    
    public int width = 15;
    public int height = 15;

    private Tile[,] tileMap;
    
    
    private void Start()
    {
        tileMap = new Tile[width, height];
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 tilepos = new Vector2(x, y);
                Tile tile = Instantiate(tilePrefab, tilepos, Quaternion.identity, this.transform);
                tile.SetTileType(TileType.Gray);
                tileMap[x, y] = tile; //배열에 저장
            }
        }
    }
}

