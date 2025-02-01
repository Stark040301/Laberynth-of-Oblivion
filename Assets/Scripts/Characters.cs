using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Characters
{
    public string characterName, characterAbility, characterAbilityName, characterHistory, characterTeam; 
    public int characterID, characterCooldown, characterMobility, characterLifePoints, cooldownTimer, abilityID;
    public Sprite characterImage, characterInfoImage;
    //[SerializeField] private GameObject[] characterPrefabs;
    public UnityEngine.Vector3 Position;
    public Vector3Int currentCell;
    public GameObject characterGO;
    
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
        characterLifePoints = 300;
        cooldownTimer = 0;

    }
}
