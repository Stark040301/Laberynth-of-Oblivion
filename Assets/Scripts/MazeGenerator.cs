using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Enum defining different types of cells in the maze
public enum CellType
{
    Wall,
    Path,
    Start,
    Trap,
    Item,
    Stone
}

// This class handles maze generation using recursive backtracking algorithm
public class MazeGenerator : MonoBehaviour
{
    // Maze dimensions
    public int rows = 17;
    public int cols = 17;

    // Tiles for different cell types
    public Tile wallTile;
    public Tile pathTile;
    public Tile startTile;
    public Tile trapTile;
    public Tile itemTile;
    public Tile stoneTile;

    // Maze data structure
    private CellType[,] maze;
    private System.Random random = new System.Random();
    private (int dx, int dy)[] directions = { (0, -1), (1, 0), (0, 1), (-1, 0) };
    [SerializeField] private GameObject mazeParent;
    private Tilemap tilemap;

    // Initialize maze generation
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        GenerateMaze();
        PlaceRandomObjects(8, 0, 17);
        RenderMaze();
        CenterCamera();
    }

    // Set a cell as path
    public void SetPath(int x, int y)
    {
        maze[x, y] = CellType.Path;
    }

    // Set a cell as start point
    public void SetStart(int x, int y)
    {
        maze[x, y] = CellType.Start;
    }

    // Set a cell as trap
    public void SetTrap(int x, int y)
    {
        maze[x, y] = CellType.Trap;
    }

    // Set a cell as item
    public void SetItem(int x, int y)
    {
        maze[x, y] = CellType.Item;
    }

    // Set a cell as stone
    public void SetStone(int x, int y)
    {
        maze[x, y] = CellType.Stone;
    }

    // Generate the maze using recursive backtracking
    public void GenerateMaze()
    {
        maze = new CellType[rows, cols];
        InitializeMaze();
        Generate(1, 15);
        SetStart(15,1);
        SetStart(1,1);
        SetStart(15,15);
    }

    // Initialize maze with walls
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

    // Recursive maze generation algorithm
    private void Generate(int x, int y)
    {
        SetPath(x,y); // Mark current cell as path
        var shuffledDirections = ShuffleDirections();

        foreach (var (dx, dy) in shuffledDirections)
        {
            int nx = x + dx * 2;
            int ny = y + dy * 2;

            if (IsInBounds(nx, ny) && maze[nx, ny] == CellType.Wall)
            {
                maze[x + dx, y + dy] = CellType.Path; // Remove wall between cells
                Generate(nx, ny); // Recurse into the next cell
            }
        }
        SetStart(1,15);
    }

    // Check if coordinates are within maze bounds
    private bool IsInBounds(int x, int y)
    {
        return x > 0 && x < rows - 1 && y > 0 && y < cols - 1;
    }

    // Shuffle directions for random maze generation
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

    // Place random objects in the maze
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

    // Render the maze using tiles
    public void RenderMaze()
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

    // Center the camera on the maze
    private void CenterCamera()
    {
        // Calculates center of the maze
        float centerX = cols / 2f;
        float centerY = rows / 2f;

        // Adjust main camera position
        Camera.main.transform.position = new Vector3(centerX, centerY, -10f);
    }
}
