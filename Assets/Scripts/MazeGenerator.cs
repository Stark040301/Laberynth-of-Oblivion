using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum CellType
{
    Wall,
    Path,
    Start,
    Trap,
    Item,
    Stone
}

public class MazeGenerator : MonoBehaviour
{
    public int rows = 25;
    public int cols = 25;

    public Tile wallTile;
    public Tile pathTile;
    public Tile startTile;
    public Tile trapTile;
    public Tile itemTile;
    public Tile stoneTile;


    private CellType[,] maze;
    private System.Random random = new System.Random();
    private (int dx, int dy)[] directions = { (0, -1), (1, 0), (0, 1), (-1, 0) };
    [SerializeField] private GameObject mazeParent;
    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMaze();
        PlaceRandomObjects(5, 5, 20);
        RenderMaze();
        CenterCamera();
    }

    public void SetPath(int x, int y)
    {
        maze[x, y] = CellType.Path;
    }

    public void SetStart(int x, int y)
    {
        maze[x, y] = CellType.Start;
    }

    public void SetTrap(int x, int y)
    {
        maze[x, y] = CellType.Trap;
    }

    public void SetItem(int x, int y)
    {
        maze[x, y] = CellType.Item;
    }

    public void SetStone(int x, int y)
    {
        maze[x, y] = CellType.Stone;
    }
    public void GenerateMaze()
    {
        maze = new CellType[rows, cols];
        InitializeMaze();
        Generate(1, 23);
        SetStart(23,1);
        SetStart(1,1);
        SetStart(23,23);
    }

    private void InitializeMaze()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                maze[i, j] = CellType.Wall;
            }
        }
    }

    private void Generate(int x, int y)
    {
        SetPath(x,y); // Mark current cell as a path
        var shuffledDirections = ShuffleDirections();

        foreach (var (dx, dy) in shuffledDirections)
        {
            int nx = x + dx * 2;
            int ny = y + dy * 2;

            if (IsInBounds(nx, ny) && maze[nx, ny] == CellType.Wall)
            {
                maze[x + dx, y + dy] = CellType.Path;// Remove wall between cells
                Generate(nx, ny);// Recurse into the next cell
            }
        }
        SetStart(1,23);
    }

    private bool IsInBounds(int x, int y)
    {
        return x > 0 && x < rows - 1 && y > 0 && y < cols - 1;
    }

    private (int dx, int dy)[] ShuffleDirections()
    {
        var shuffled = directions.Clone() as (int dx, int dy)[];
        for (int i = shuffled.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
        }
        return shuffled;
    }

    public void PlaceRandomObjects(int numTraps, int numItems, int numStones)
    {
        int placedTraps = 0, placedItems = 0, placedStones = 0;
        while (placedTraps < numTraps || placedItems < numItems || placedStones < numStones)
        {
            int x = random.Next(1, rows - 1);
            int y = random.Next(1, cols - 1);

            if (maze[x, y] == CellType.Path)
            {
                if (placedTraps < numTraps)
                {
                    maze[x, y] = CellType.Trap;
                    placedTraps++;
                }
                else if (placedItems < numItems)
                {
                    maze[x, y] = CellType.Item;
                    placedItems++;
                }
                else if (placedStones < numStones)
                {
                    maze[x, y] = CellType.Stone;
                    placedStones++;
                }
            }
        }
    }

    private void RenderMaze()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3Int cellPosition = new Vector3Int(i, j, 0);
                Tile tile = null;

                switch (maze[i, j])
                {
                    case CellType.Wall:
                        tile = wallTile;
                        break;
                    case CellType.Path:
                        tile = pathTile;
                        break;
                    case CellType.Start:
                        tile = startTile;
                        break;
                    case CellType.Trap:
                        tile = trapTile;
                        break;
                    case CellType.Item:
                        tile = itemTile;
                        break;
                    case CellType.Stone:
                        tile = stoneTile;
                        break;
                }

                if (tile != null)
                {
                    tilemap.SetTile(cellPosition, tile);
                }
            }
        }
    }
    private void CenterCamera()
    {
        // Calcula el centro del laberinto
        float centerX = cols / 2f;
        float centerY = rows / 2f;

        // Ajusta la posición de la Main Camera
        Camera.main.transform.position = new Vector3(centerX, centerY, -10f);
    }
}


