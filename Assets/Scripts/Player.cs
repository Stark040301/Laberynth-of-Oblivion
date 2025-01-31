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

    public Player(int playerIndex, string playerName, List<Characters> team, Vector3Int startPosition)
    {
        this.playerIndex = playerIndex;
        this.playerName = playerName;
        this.team = team;
        this.startPosition = startPosition;
        playerTeam = team[0].characterTeam;
        currentCharacterIndex = 0;
        remainingSteps = 0;
        collectedStones = 0;
    }
}
