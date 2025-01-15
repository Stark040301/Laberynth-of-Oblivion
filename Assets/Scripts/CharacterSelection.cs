using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Text[] characterNameTexts;
    [SerializeField] private Image[] characterImages;
    [SerializeField] private Image[] characterInfoImages;

    void Start()
    {
        DataBase.InitializeCharacters();
        // Suscribir el evento al método
        dropdown.onValueChanged.AddListener(UpdateCharacterNames);

        // Inicializar los textos al inicio
        UpdateCharacterNames(dropdown.value);
    }
    
    void UpdateCharacterNames(int index)
    {
        List<Characters> selectedTeam = index switch
        {
            0 => DataBase.AnimeTeam,
            1 => DataBase.FilmTeam,
            2 => DataBase.DisneyTeam,
            3 => DataBase.MarvelTeam,
            _ => new List<Characters>()
        };

        for (int i = 0; i < characterNameTexts.Length; i++)
        {
            characterNameTexts[i].text = selectedTeam[i].characterName;
        }
        for (int i = 0; i < characterImages.Length; i++)
        {
            characterImages[i].sprite = selectedTeam[i].characterImage;
        }
    }

}
