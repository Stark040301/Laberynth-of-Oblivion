using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject wallSprite;
    public GameObject pathSprite;
    public GameObject startSprite;
    public GameObject trapSprite;
    public GameObject itemSprite;
    public GameObject stoneSprite;

    private CellType[,] maze;
    private System.Random random = new System.Random();
    private (int dx, int dy)[] directions = { (0, -1), (1, 0), (0, 1), (-1, 0) };
    private GameObject mazeParent;

    void Start()
    {
        GenerateMaze();
        CenterCamera();
        PlaceRandomObjects(7, 5, 10);
        RenderMaze();
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
        Generate(1, 19);
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
        SetStart(1,19);
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
        //Create an empty gameObject to store the maze
        mazeParent = new GameObject("Maze");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Vector3 position = new Vector3(i, j, 0);
                GameObject prefab = null;

                switch (maze[i, j])
                {
                    case CellType.Wall:
                        prefab = wallSprite;
                        break;
                    case CellType.Path:
                        prefab = pathSprite;
                        break;
                    case CellType.Start:
                        prefab = startSprite;
                        break;
                    case CellType.Trap:
                        prefab = trapSprite;
                        break;
                    case CellType.Item:
                        prefab = itemSprite;
                        break;
                    case CellType.Stone:
                        prefab = stoneSprite;
                        break;
                }

                if (prefab != null)
                {
                    //Instantiate and asings as a children of maze GameObject
                    GameObject tile = Instantiate(prefab, position, Quaternion.identity);
                    tile.transform.SetParent(mazeParent.transform);
                    
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


