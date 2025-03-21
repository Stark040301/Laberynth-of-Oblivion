using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// This class represents a player in the game
public class Player
{
    // Player information
    public string playerName;
    public string playerTeam;
    
    // Player's team of characters
    public List<Characters> team;
    
    // Player's starting position in the maze
    public Vector3Int startPosition;
    
    // Game state variables
    public int playerIndex;
    public int currentCharacterIndex;
    public int remainingSteps;
    public int collectedStones;
    public int turnCounter;
    public bool isProtected;

    // Constructor to initialize a new player
    public Player(int playerIndex, int turnCounter, string playerName, List<Characters> team, Vector3Int startPosition)
    {
        this.playerIndex = playerIndex;
        this.playerName = playerName;
        this.team = team;
        this.startPosition = startPosition;
        this.turnCounter = turnCounter;
        
        // Initialize additional player state
        playerTeam = team[0].characterTeam;
        currentCharacterIndex = 0;
        remainingSteps = 0;
        collectedStones = 0;
        isProtected = false;
    }
}
