using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class handles character selection for the game
public class CharacterSelection : MonoBehaviour
{
    // UI elements for character selection
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject nextPlayerUI;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Text[] characterNameTexts;
    [SerializeField] private TMP_Text playerIndicator;
    [SerializeField] private TMP_Text nextPlayerIndicator;
    [SerializeField] private TMP_Text selectedCharacterName;
    [SerializeField] private TMP_Text selectedCharacterAbility;
    [SerializeField] private TMP_Text selectedCharacterCooldown;
    [SerializeField] private TMP_Text selectedCharacterMobility;
    [SerializeField] private TMP_Text selectedCharacterHistory;
    [SerializeField] private Image[] characterImages;
    [SerializeField] private Image characterInfoImage;
    [SerializeField] private Image[] buttonImages;

    // Lists to store selected characters for each player
    public List<Characters> selectedPlayerTeam = new List<Characters>();
    public List<Characters> player1Team = new List<Characters>();
    public List<Characters> player2Team = new List<Characters>();
    public List<Characters> player3Team = new List<Characters>();
    public List<Characters> player4Team = new List<Characters>();

    // Flags to track selected characters
    private bool Ischar1 = false;
    private bool Ischar2 = false;
    private bool Ischar3 = false;
    private bool Ischar4 = false;
    private bool Ischar5 = false;
    int currentPlayer = 1;

    // Initialize character selection
    void Start()
    {
        DataBase.InitializeCharacters();
        dropdown.onValueChanged.AddListener(UpdateCharacterNames);
        UpdateCharacterNames(dropdown.value);
    }
    
    // Update character names and images based on selected team
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

    // Clear selected characters and reset UI
    public void ClearSelectedCharacters()
    {
        selectedPlayerTeam.Clear();
        Ischar1 = false;
        Ischar2 = false;
        Ischar3 = false;
        Ischar4 = false;
        Ischar5 = false;
        foreach (Image button in buttonImages)
        {
            button.color = Color.white;
        }
    }

    // Start the game with selected characters
    public void StartGame()
    {
        if (currentPlayer == 2)
        {
            if (selectedPlayerTeam.Count == 3 && selectedPlayerTeam[0].characterTeam != player1Team[0].characterTeam)
            {
                player2Team = new List<Characters>(selectedPlayerTeam);                
                Player player1 = new Player(0, 0, "Player 1", player1Team, new Vector3Int(1,15,0));
                Player player2 = new Player(1, -1, "Player 2", player2Team, new Vector3Int(15,15,0));
                PlayerHandler.playerList.Add(player1);
                PlayerHandler.playerList.Add(player2);
                ClearSelectedCharacters();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (currentPlayer == 3)
        {
            if (selectedPlayerTeam.Count == 3 && selectedPlayerTeam[0].characterTeam != player1Team[0].characterTeam && selectedPlayerTeam[0].characterTeam != player2Team[0].characterTeam)
            {
                player3Team = new List<Characters>(selectedPlayerTeam);                
                Player player1 = new Player(0, 0, "Player 1", player1Team, new Vector3Int(1,15,0));
                Player player2 = new Player(1, -1, "Player 2", player2Team, new Vector3Int(15,15,0));
                Player player3 = new Player(2, -1, "Player 3", player3Team, new Vector3Int(15,1,0));
                PlayerHandler.playerList.Add(player1);
                PlayerHandler.playerList.Add(player2);
                PlayerHandler.playerList.Add(player3);
                ClearSelectedCharacters();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (currentPlayer == 4)
        {
            if (selectedPlayerTeam.Count == 3 && selectedPlayerTeam[0].characterTeam != player1Team[0].characterTeam && selectedPlayerTeam[0].characterTeam != player2Team[0].characterTeam && selectedPlayerTeam[0].characterTeam != player3Team[0].characterTeam)
            {
                player4Team = new List<Characters>(selectedPlayerTeam);                
                Player player1 = new Player(0, 0, "Player 1", player1Team, new Vector3Int(1,15,0));
                Player player2 = new Player(1, -1, "Player 2", player2Team, new Vector3Int(15,15,0));
                Player player3 = new Player(2, -1, "Player 3", player3Team, new Vector3Int(15,1,0));
                Player player4 = new Player(3, -1, "Player 4", player4Team, new Vector3Int(1,1,0));
                PlayerHandler.playerList.Add(player1);
                PlayerHandler.playerList.Add(player2);
                PlayerHandler.playerList.Add(player3);
                PlayerHandler.playerList.Add(player4);
                ClearSelectedCharacters();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        foreach (Characters character in player1Team)
        {
            Debug.Log(character.characterName);
        }
        foreach (Characters character in player2Team)
        {
            Debug.Log(character.characterName);
        }
        foreach (Characters character in player3Team)
        {
            Debug.Log(character.characterName);
        }
        foreach (Characters character in player4Team)
        {
            Debug.Log(character.characterName);
        }
    }

    // Go back to previous screen
    public void GoBack()
    {
        if (currentPlayer == 1)
        {
            ClearSelectedCharacters();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (currentPlayer == 2)
        {
            player2Team.Clear();
            playerIndicator.text = "Player 1";
            nextPlayerIndicator.text = "Player 2";
            ClearSelectedCharacters();
            startGameButton.SetActive(false);
            currentPlayer--;
        }
        else if (currentPlayer == 3)
        {
            player3Team.Clear();
            playerIndicator.text = "Player 2";
            nextPlayerIndicator.text = "Player 3";
            ClearSelectedCharacters();
            currentPlayer--;
        }
        else if (currentPlayer == 4)
        {
            player4Team.Clear();
            nextPlayerUI.SetActive(true);
            playerIndicator.text = "Player 3";
            nextPlayerIndicator.text = "Player 4";
            ClearSelectedCharacters();
            currentPlayer--;
        }
        ClearUI();
    }

    // Move to next player's selection
    public void NextPlayers()
    {
        if (currentPlayer == 1)
        {
            if (selectedPlayerTeam.Count == 3)
            {
                player1Team = new List<Characters>(selectedPlayerTeam);                
                ClearSelectedCharacters();
                foreach (Characters character in player1Team)
                {
                    Debug.Log(character.characterName);
                }
                playerIndicator.text = "Player 2";
                nextPlayerIndicator.text = "Player 3";
                currentPlayer++;
                startGameButton.SetActive(true);
            }
        }
        else if (currentPlayer == 2)
        {
            if (selectedPlayerTeam.Count == 3 && selectedPlayerTeam[0].characterTeam != player1Team[0].characterTeam)
            {
                player2Team = new List<Characters>(selectedPlayerTeam);                
                ClearSelectedCharacters();
                playerIndicator.text = "Player 3";
                nextPlayerIndicator.text = "Player 4";
                currentPlayer++;
            }
        }
        else if (currentPlayer == 3)
        {
            if (selectedPlayerTeam.Count == 3 && selectedPlayerTeam[0].characterTeam != player1Team[0].characterTeam && selectedPlayerTeam[0].characterTeam != player2Team[0].characterTeam)
            {
                player3Team = new List<Characters>(selectedPlayerTeam);                
                ClearSelectedCharacters();
                playerIndicator.text = "Player 4";
                nextPlayerIndicator.text = "";
                currentPlayer++;
                nextPlayerUI.SetActive(false);
            }
        }
        ClearUI();
    }

    // Select a character
    public void SelectCharacters()
    {
        int index = dropdown.value;
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "Char1":
                if(Ischar1)
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[0] || character == DataBase.FilmTeam[0] || character == DataBase.DisneyTeam[0] || character == DataBase.MarvelTeam[0])// This is for unselecting characters
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        ClearUI();
                        }
                    }
                    buttonImages[0].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar1)
                    {
                        Characters character = null;
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[0]);
                            character = DataBase.AnimeTeam[0];
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[0]);
                            character = DataBase.FilmTeam[0];
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[0]);
                            character = DataBase.DisneyTeam[0];
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[0]);
                            character = DataBase.MarvelTeam[0];
                        }
                        buttonImages[0].color = Color.green;
                        if (character != null)
                        {
                            selectedCharacterName.text = character.characterName;
                            selectedCharacterAbility.text = $"Habilidad: {character.characterAbilityName}:\n{character.characterAbility}";
                            selectedCharacterMobility.text = $"Movilidad: {character.characterMobility} casillas";
                            selectedCharacterCooldown.text = $"Enfriamiento: {character.characterCooldown} turnos";
                            selectedCharacterHistory.text = $"Historia: {character.characterHistory}";
                            characterInfoImage.sprite = character.characterInfoImage;
                        }
                    }

                    if (Ischar1)
                    {
                        Ischar1 = false;
                    }
                    else
                    {
                        Ischar1 = true;
                    }
                }
                break;
            case "Char2":
                if(Ischar2)
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[1] || character == DataBase.FilmTeam[1] || character == DataBase.DisneyTeam[1] || character == DataBase.MarvelTeam[1])
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        ClearUI();
                        }
                    }
                    buttonImages[1].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar2)
                    {
                        Characters character = null;
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[1]);
                            character = DataBase.AnimeTeam[1];
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[1]);
                            character = DataBase.FilmTeam[1];
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[1]);
                            character = DataBase.DisneyTeam[1];
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[1]);
                            character = DataBase.MarvelTeam[1];
                        }
                        buttonImages[1].color = Color.green;
                        if (character != null)
                        {
                            selectedCharacterName.text = character.characterName;
                            selectedCharacterAbility.text = $"Habilidad: {character.characterAbilityName}:\n{character.characterAbility}";
                            selectedCharacterMobility.text = $"Movilidad: {character.characterMobility} casillas";
                            selectedCharacterCooldown.text = $"Enfriamiento: {character.characterCooldown} turnos";
                            selectedCharacterHistory.text = $"Historia: {character.characterHistory}";
                            characterInfoImage.sprite = character.characterInfoImage;
                        }
                    }

                    if (Ischar2)
                    {
                        Ischar2 = false;
                    }
                    else
                    {
                        Ischar2 = true;
                    }
                }
                break;
            case "Char3":
                if(Ischar3)
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[2] || character == DataBase.FilmTeam[2] || character == DataBase.DisneyTeam[2] || character == DataBase.MarvelTeam[2])
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        ClearUI();
                        }
                    }
                    buttonImages[2].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar3)
                    {
                        Characters character = null;
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[2]);
                            character = DataBase.AnimeTeam[2];
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[2]);
                            character = DataBase.FilmTeam[2];
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[2]);
                            character = DataBase.DisneyTeam[2];
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[2]);
                            character = DataBase.MarvelTeam[2];
                        }
                        buttonImages[2].color = Color.green;
                        if (character != null)
                        {
                            selectedCharacterName.text = character.characterName;
                            selectedCharacterAbility.text = $"Habilidad: {character.characterAbilityName}:\n{character.characterAbility}";
                            selectedCharacterMobility.text = $"Movilidad: {character.characterMobility} casillas";
                            selectedCharacterCooldown.text = $"Enfriamiento: {character.characterCooldown} turnos";
                            selectedCharacterHistory.text = $"Historia: {character.characterHistory}";
                            characterInfoImage.sprite = character.characterInfoImage;
                        }
                    }

                    if (Ischar3)
                    {
                        Ischar3 = false;
                    }
                    else
                    {
                        Ischar3 = true;
                    }
                }
                break;
            case "Char4":
                if(Ischar4)
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[3] || character == DataBase.FilmTeam[3] || character == DataBase.DisneyTeam[3] || character == DataBase.MarvelTeam[3])
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        ClearUI();
                        }
                    }
                    buttonImages[3].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar4)
                    {
                        Characters character = null;
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[3]);
                            character = DataBase.AnimeTeam[3];
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[3]);
                            character = DataBase.FilmTeam[3];
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[3]);
                            character = DataBase.DisneyTeam[3];
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[3]);
                            character = DataBase.MarvelTeam[3];
                        }
                        buttonImages[3].color = Color.green;
                        if (character != null)
                        {
                            selectedCharacterName.text = character.characterName;
                            selectedCharacterAbility.text = $"Habilidad: {character.characterAbilityName}:\n{character.characterAbility}";
                            selectedCharacterMobility.text = $"Movilidad: {character.characterMobility} casillas";
                            selectedCharacterCooldown.text = $"Enfriamiento: {character.characterCooldown} turnos";
                            selectedCharacterHistory.text = $"Historia: {character.characterHistory}";
                            characterInfoImage.sprite = character.characterInfoImage;
                        }
                    }

                    if (Ischar4)
                    {
                        Ischar4 = false;
                    }
                    else
                    {
                        Ischar4 = true;
                    }
                }
                break;
            case "Char5":
                if(Ischar5)
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[4] || character == DataBase.FilmTeam[4] || character == DataBase.DisneyTeam[4] || character == DataBase.MarvelTeam[4])
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        ClearUI();
                        }
                    }
                    buttonImages[4].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar5)
                    {
                        Characters character = null;
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[4]);
                            character = DataBase.AnimeTeam[4];
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[4]);
                            character = DataBase.FilmTeam[4];
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[4]);
                            character = DataBase.DisneyTeam[4];
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[4]);
                            character = DataBase.MarvelTeam[4];
                        }
                        buttonImages[4].color = Color.green;
                        if (character != null)
                        {
                            selectedCharacterName.text = character.characterName;
                            selectedCharacterAbility.text = $"Habilidad: {character.characterAbilityName}:\n{character.characterAbility}";
                            selectedCharacterMobility.text = $"Movilidad: {character.characterMobility} casillas";
                            selectedCharacterCooldown.text = $"Enfriamiento: {character.characterCooldown} turnos";
                            selectedCharacterHistory.text = $"Historia: {character.characterHistory}";
                            characterInfoImage.sprite = character.characterInfoImage;
                        }
                    }

                    if (Ischar5)
                    {
                        Ischar5 = false;
                    }
                    else
                    {
                        Ischar5 = true;
                    }
                }
                break;
            default:
                Debug.LogError("Unknown button!");
                break;
        }
    }

    // Clear character info UI
    public void ClearUI()
    {
        selectedCharacterName.text = "";
        selectedCharacterAbility.text = "";
        selectedCharacterMobility.text = "";
        selectedCharacterCooldown.text = "";
        selectedCharacterHistory.text = "";
        characterInfoImage.sprite = Resources.Load<Sprite>("EI");
    }
}
