using System.IO;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile tilePrefab;
    public int width = 15;
    public int height = 15;
    private Tile[,] tileMap;
    private TileType currentPaintType;
    
    [System.Serializable]
    public class TileData
    {
        public int x;
        public int y;
        public string type;
    }

    [System.Serializable]
    public class TileDataList
    {
        public TileData[] tiles;
    }


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
                tileMap[x, y] = tile;
            }
        }
    }



    private void VerticalLine()
    {
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                tileMap[i, j].SetTileType(TileType.Red);
                
            }
        }
    }
    
    // 타일맵 구성하는 키
    private void Update()
    {
        // 키보드 숫자 키로 '붓'의 종류를 변경합니다.
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentPaintType = TileType.Gray;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentPaintType = TileType.Green;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentPaintType = TileType.Red;
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentPaintType = TileType.Yellow;
        if (Input.GetKeyDown(KeyCode.Alpha5)) currentPaintType = TileType.Blue;
        if (Input.GetKeyDown(KeyCode.Alpha6)) currentPaintType = TileType.Purple;

        // 마우스 왼쪽 버튼 클릭 또는 드래그 시 타일을 칠합니다.
        if (Input.GetMouseButton(0))
        {
            PaintTileAtMousePosition();
        }
    }

    private void PaintTileAtMousePosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            Tile clickedTile = hit.collider.GetComponent<Tile>();
            if (clickedTile != null)
            {
                if (clickedTile.currentType != currentPaintType)
                {
                    clickedTile.SetTileType(currentPaintType);
                }
            }
        }
    }
    
    
    // JSON에 저장
    public void SaveToJson()
    {
        TileDataList dataList = new TileDataList();
        dataList.tiles = new TileData[width * height];
        int index = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile t = tileMap[x, y];
                dataList.tiles[index++] = new TileData
                {
                    x = x,
                    y = y,
                    type = t.currentType.ToString()
                };
            }
        }

        string json = JsonUtility.ToJson(dataList, true);
        string path = Path.Combine(Application.dataPath, "stage1_03.json");
        File.WriteAllText(path, json);
        Debug.Log("저장 완료: " + path);
    }

    
    // JSON 로더
    public void LoadFromJson()
    {
        string path = Path.Combine(Application.dataPath, "./Json/stage1_03.json");

        string json = File.ReadAllText(path);
        TileDataList dataList = JsonUtility.FromJson<TileDataList>(json);

        foreach (TileData td in dataList.tiles)
        {
            tileMap[td.x, td.y].SetTileType((TileType)System.Enum.Parse(typeof(TileType), td.type));
        }

        VerticalLine();

        Debug.Log("로드 완료");
    }
}