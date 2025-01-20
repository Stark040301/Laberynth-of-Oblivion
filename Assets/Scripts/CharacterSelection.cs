using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject nextPlayerUI;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Text[] characterNameTexts;
    [SerializeField] private TMP_Text playerIndicator;
    [SerializeField] private TMP_Text nextPlayerIndicator;
    [SerializeField] private Image[] characterImages;
    [SerializeField] private Image[] characterInfoImages;
    [SerializeField] private Image[] buttonImages;
    public List<Characters> selectedPlayerTeam = new List<Characters>();
    public List<Characters> player1Team = new List<Characters>();
    public List<Characters> player2Team = new List<Characters>();
    public List<Characters> player3Team = new List<Characters>();
    public List<Characters> player4Team = new List<Characters>();
    private bool Ischar1 = false;
    private bool Ischar2 = false;
    private bool Ischar3 = false;
    private bool Ischar4 = false;
    private bool Ischar5 = false;
    int currentPlayer = 1;

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
    public void StartGame()
    {
        if (currentPlayer == 2)
        {
            if (selectedPlayerTeam.Count == 3)
            {
                player2Team = selectedPlayerTeam;
                ClearSelectedCharacters();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (currentPlayer == 3)
        {
            if (selectedPlayerTeam.Count == 3)
            {
                player3Team = selectedPlayerTeam;
                ClearSelectedCharacters();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (currentPlayer == 4)
        {
            if (selectedPlayerTeam.Count == 3)
            {
                player4Team = selectedPlayerTeam;
                ClearSelectedCharacters();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
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
    }
    public void NextPlayers()
    {
        if (currentPlayer == 1)
        {
            if (selectedPlayerTeam.Count == 3)
            {
                player1Team = selectedPlayerTeam;
                ClearSelectedCharacters();
                playerIndicator.text = "Player 2";
                nextPlayerIndicator.text = "Player 3";
                currentPlayer++;
                startGameButton.SetActive(true);
            }
        }
        else if (currentPlayer == 2)
        {
            if (selectedPlayerTeam.Count == 3)
            {
                player2Team = selectedPlayerTeam;
                ClearSelectedCharacters();
                playerIndicator.text = "Player 3";
                nextPlayerIndicator.text = "Player 4";
                currentPlayer++;
            }
        }
        else if (currentPlayer == 3)
        {
            if (selectedPlayerTeam.Count == 3)
            {
                player3Team = selectedPlayerTeam;
                ClearSelectedCharacters();
                playerIndicator.text = "Player 4";
                nextPlayerIndicator.text = "";
                currentPlayer++;
                nextPlayerUI.SetActive(false);
            }
        }
    }

    public void SelectCharacters()
    {
        int index = dropdown.value;
        string buttonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (buttonName)
        {
            case "Char1":
                if(Ischar1)//This is for unselecting selected characters
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[0] || character == DataBase.FilmTeam[0] || character == DataBase.DisneyTeam[0] || character == DataBase.MarvelTeam[0])//This is for unselecting selected characters
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        }
                    }
                    buttonImages[0].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar1)
                    {
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[0]);
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[0]);
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[0]);
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[0]);
                        }
                        buttonImages[0].color = Color.green;
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
                if(Ischar2)//This is for unselecting selected characters
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[1] || character == DataBase.FilmTeam[1] || character == DataBase.DisneyTeam[1] || character == DataBase.MarvelTeam[1])//This is for unselecting selected characters
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        }
                    }
                    buttonImages[1].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar2)
                    {
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[1]);
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[1]);
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[1]);
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[1]);
                        }
                        buttonImages[1].color = Color.green;
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
                if(Ischar3)//This is for unselecting selected characters
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[2] || character == DataBase.FilmTeam[2] || character == DataBase.DisneyTeam[2] || character == DataBase.MarvelTeam[2])//This is for unselecting selected characters
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        }
                    }
                    buttonImages[2].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar3)
                    {
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[2]);
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[2]);
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[2]);
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[2]);
                        }
                        buttonImages[2].color = Color.green;
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
                if(Ischar4)//This is for unselecting selected characters
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[3] || character == DataBase.FilmTeam[3] || character == DataBase.DisneyTeam[3] || character == DataBase.MarvelTeam[3])//This is for unselecting selected characters
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        }
                    }
                    buttonImages[3].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar4)
                    {
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[3]);
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[3]);
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[3]);
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[3]);
                        }
                        buttonImages[3].color = Color.green;
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
                if(Ischar5)//This is for unselecting selected characters
                {
                    for (int i = selectedPlayerTeam.Count - 1; i >= 0 ; i--)
                    {
                        Characters character = selectedPlayerTeam[i];
                        if( character == DataBase.AnimeTeam[4] || character == DataBase.FilmTeam[4] || character == DataBase.DisneyTeam[4] || character == DataBase.MarvelTeam[4])//This is for unselecting selected characters
                        {
                        selectedPlayerTeam.RemoveAt(i);
                        Debug.Log(character.characterName + "Unselected");
                        }
                    }
                    buttonImages[4].color = Color.white;
                }

                if (selectedPlayerTeam.Count < 3)
                {
                    if (!Ischar5)
                    {
                        if (index == 0)
                        {
                            selectedPlayerTeam.Add(DataBase.AnimeTeam[4]);
                        }
                        else if (index == 1)
                        {
                            selectedPlayerTeam.Add(DataBase.FilmTeam[4]);
                        }
                        else if (index ==2)
                        {
                            selectedPlayerTeam.Add(DataBase.DisneyTeam[4]);
                        }
                        else if (index ==3)
                        {
                            selectedPlayerTeam.Add(DataBase.MarvelTeam[4]);
                        }
                        buttonImages[4].color = Color.green;
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
        Debug.Log("Personajes seleccionados en el equipo:");
        foreach (Characters character in selectedPlayerTeam)
        {
            Debug.Log(character.characterName);
        }
    }

}
