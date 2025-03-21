using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

// This class represents a character in the game
public class Characters
{
    // Character attributes
    public string characterName, characterAbility, characterAbilityName, characterHistory, characterTeam; 
    
    // Character stats and identifiers
    public int characterID, characterCooldown, characterMobility, characterLifePoints, cooldownTimer, abilityID;
    
    // Visual elements
    public Sprite characterImage, characterInfoImage;
    
    // Position and game object
    public UnityEngine.Vector3 Position;
    public Vector3Int currentCell;
    public GameObject characterGO;
    
    // Constructor to initialize a new character
    public Characters(int characterID, int abilityID, string characterName, string characterTeam, string characterAbilityName, string characterAbility, string characterHistory, int characterCooldown, int characterMobility, Sprite characterImage, Sprite characterInfoImage)
    {
        this.characterID = characterID;
        this.characterName = characterName;
        this.characterAbility = characterAbility;
        this.characterAbilityName = characterAbilityName;
        this.characterHistory = characterHistory;
        this.characterCooldown = characterCooldown;
        this.characterMobility = characterMobility;
        this.characterImage = characterImage;
        this.characterInfoImage = characterInfoImage;
        this.characterTeam = characterTeam;
        this.abilityID = abilityID;
        
        // Initialize default values
        characterLifePoints = 300;
        cooldownTimer = 0;
    }
}
