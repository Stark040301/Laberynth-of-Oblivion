using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Player
{
    public string playerName;
    public string playerTeam;
    public List<Characters> team;
    public Vector3Int startPosition;
    public int playerIndex;
    public int currentCharacterIndex;
    public int remainingSteps;
    public int collectedStones;
    public int turnCounter;
    public bool isProtected;

    public Player(int playerIndex, int turnCounter, string playerName, List<Characters> team, Vector3Int startPosition)
    {
        this.playerIndex = playerIndex;
        this.playerName = playerName;
        this.team = team;
        this.startPosition = startPosition;
        this.turnCounter = turnCounter;
        playerTeam = team[0].characterTeam;
        currentCharacterIndex = 0;
        remainingSteps = 0;
        collectedStones = 0;
        isProtected = false;
    }
}
