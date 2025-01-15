using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters
{
    public string characterName, characterAbility, characterAbilityName, characterHistory; 
    public int characterCooldown, characterMobility, characterLifePoints;
    public Sprite characterImage, characterInfoImage;
    public Characters(string characterName, string characterAbility, string characterAbilityName, string characterHistory, int characterCooldown, int characterMobility, Sprite characterImage, Sprite characterInfoImage)
    {
        this.characterName = characterName;
        this.characterAbility = characterAbility;
        this.characterAbilityName = characterAbilityName;
        this.characterHistory = characterHistory;
        this.characterCooldown = characterCooldown;
        this.characterMobility = characterMobility;
        this.characterImage = characterImage;
        this.characterInfoImage = characterInfoImage;
        characterLifePoints = 300;

    }
}
