using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class PlayerHandler : MonoBehaviour
    // This class handles player actions, movements, and game state management.
{
    [SerializeField] public Tilemap tilemap;
    // Background object for the scene
    public GameObject scBackground;
    // GameObjects representing characters
    public GameObject C1; // Character 1
    public GameObject C2; // Character 2
    public GameObject C3; // Character 3
    public GameObject P3; // Panel for Player 3
    public GameObject P4; // Panel for Player 4
    public GameObject P3Panel; // UI Panel for Player 3
    public GameObject P4Panel; // UI Panel for Player 4
    public GameObject P1Button; // Button for Player 1 actions
    public GameObject P2Button; // Button for Player 2 actions
    public GameObject P3Button; // Button for Player 3 actions
    public GameObject P4Button; // Button for Player 4 actions
    [SerializeField] private TMP_Text[] abilityText;
    [SerializeField] private TMP_Text[] characterNamesText;
    [SerializeField] private TMP_Text[] currentMobility;
    [SerializeField] private TMP_Text[] colectedStonesText;
    [SerializeField] private TMP_Text[] cooldownText;
    [SerializeField] private Image[] targetCharactersImages;
    [SerializeField] private Image[] P1CharacterLife;
    [SerializeField] private Image[] P2CharacterLife;
    [SerializeField] private Image[] P3CharacterLife;
    [SerializeField] private Image[] P4CharacterLife;
    private System.Random random = new System.Random();
    public Characters _targetCharacter;
    public Player _targetPlayer;
    public bool selectTarget = false;
    public bool player1Move = false;
    public bool player3Move = false;
    public bool player2Move = false;
    public bool player4Move = false;
    // Static variables to track if players have won
    public static bool p1HasWon = false;
    public static bool p2HasWon = false;
    public static bool p3HasWon = false;
    public static bool p4HasWon = false;
    public int currentPlayerIndex;
    public int totalPlayers;
    public static Player currentPlayer;
    public static Characters selectedCharacter;
    [SerializeField] private List<GameObject> characterPrefabs; // Lista de prefabs de los personajes
    [SerializeField] private Image[] Player1CharacterImageList; // Lista de imágenes de los personajes en juego
    [SerializeField] private Image[] Player2CharacterImageList; // Lista de imágenes de los personajes en juego
    [SerializeField] private Image[] Player3CharacterImageList; // Lista de imágenes de los personajes en juego
    [SerializeField] private Image[] Player4CharacterImageList; // Lista de imágenes de los personajes en juego
    public static List<Player> playerList = new List<Player>(); // Lista de personajes en el juego
    private int p1RemainingSteps; // Pasos restantes en este turno
    private int p2RemainingSteps;
    private int p3RemainingSteps;
    private int p4RemainingSteps;
    private Vector3Int currentCell; // Celda actual en coordenadas del Tilemap
    public Tile wallTile; // Tile que representa una pared
    public Tile stoneTile; // Tile que representa una piedra
    public Tile trapTile; // Tile que representa una trampa
    public Tile itemTile; // Tile que representa un item
    public Tile pathTile; // Tile que representa un item
    private SoundManager soundManager;
    private void Start()
    {

    }
    void Awake()
    {
        totalPlayers = playerList.Count;
        if (totalPlayers < 4)
        {
            P4Panel.SetActive(false);
        }
        if (totalPlayers < 3)
        {
            P3Panel.SetActive(false);
        }
        currentPlayer = playerList[0];
        PlaceCharacters();
        SetImages();
        SetText();
        PlayersTurns();
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Method to manage player turns
    public void PlayersTurns()
    {
        if (currentPlayer == playerList[0])
        {
            selectedCharacter = currentPlayer.team[0];
            SetSpecificText(0,0);
        }
        if (currentPlayer == playerList[1])
        {
            selectedCharacter = currentPlayer.team[0];
            SetSpecificText(1,0);
        }
        if (totalPlayers >= 3)
        {
            if (currentPlayer == playerList[2])
            {
                selectedCharacter = currentPlayer.team[0];
                SetSpecificText(2,0);
            }
        }
        if (totalPlayers == 4)
        {
            if (currentPlayer == playerList[3])
            {
                selectedCharacter = currentPlayer.team[0];
                SetSpecificText(3,0);
            } 
        }  
    }
    void Update()
    {
        if (player1Move)
        {
            MoveCharacter(selectedCharacter);
        }
        if (player2Move)
        {
            MoveCharacter(selectedCharacter);
        }
        if (player3Move)
        {
            MoveCharacter(selectedCharacter);
        }
        if (player4Move)
        {
            MoveCharacter(selectedCharacter);
        }

        VictoryCondition();
    }

    // Method to move the selected character based on player input
    private void MoveCharacter(Characters character)
    {
        if (currentPlayer.remainingSteps > 0)
        {
            Vector3Int direction = Vector3Int.zero;
            // Detectar las flechas del teclado
            if (Input.GetKeyDown(KeyCode.UpArrow))
                direction = new Vector3Int(0, 1, 0);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                direction = new Vector3Int(0, -1, 0);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                direction = new Vector3Int(-1, 0, 0);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                direction = new Vector3Int(1, 0, 0);

            if (direction != Vector3Int.zero)
            {
                // Calcular la celda destino
                Vector3Int targetCell = character.currentCell + direction;
                TileBase targetTileBase = tilemap.GetTile(targetCell);
                Tile targetTile = targetTileBase as Tile;

                // Verificar si la celda destino no es una pared
                if (targetTile != wallTile)
                {
                    // Mover el prefab del personaje
                    character.characterGO.transform.position = tilemap.CellToWorld(targetCell) + cellCenterOffset();
                    character.currentCell = targetCell; // Actualizar la celda actual
                    currentPlayer.remainingSteps--; // Reducir los pasos restantes
                    currentMobility[currentPlayer.playerIndex].text = "" + currentPlayer.remainingSteps;
                }
                else
                {
                    Debug.Log("No puedes moverte a una celda con pared.");
                }
                if (targetTile == stoneTile)
                {
                    currentPlayer.collectedStones++;
                    tilemap.SetTile(targetCell, pathTile);
                    colectedStonesText[currentPlayer.playerIndex].text = "" +  currentPlayer.collectedStones;            
                }
                if (targetTile == trapTile)
                {
                    int z = random.Next(2);
                    switch (z)
                    {
                        case 0:
                            SendToStartTrap();
                            break;
                        case 1:
                            StoneTrap();
                            break;
                        case 2:
                            CooldownTrap();
                            break;
                    } 
                    tilemap.SetTile(targetCell, pathTile);
                }
                if (targetTile == itemTile)
                {
                    tilemap.SetTile(targetCell, pathTile);
                }
            }
        }
        else
        {
            Debug.Log("El personaje no tiene pasos restantes.");
        }
    }
    // Method to set character images in the UI
    private void SetImages()
    {
        if (playerList.Count > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Player1CharacterImageList[i].sprite = playerList[0].team[i].characterImage;
            }
        }
        if (playerList.Count > 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Player2CharacterImageList[i].sprite = playerList[1].team[i].characterImage;
            }
        }
        if (playerList.Count > 2)
        {
            for (int i = 0; i < 3; i++)
            {
                Player3CharacterImageList[i].sprite = playerList[2].team[i].characterImage;
            }
        }
        if (playerList.Count > 3)
        {
            for (int i = 0; i < 3; i++)
            {
                Player4CharacterImageList[i].sprite = playerList[3].team[i].characterImage;
            }
        }
    }
    // Method to update text fields in the UI
    private void SetText()
    {
        SetSpecificText(0,0);
        SetSpecificText(1,0);
        if (playerList.Count >= 3)
        {
            SetSpecificText(2,0);            
        }
        if (playerList.Count == 4)
        {
            SetSpecificText(3,0);           
        }
    }
    private void SetSpecificText(int teamIndex, int charIndex)
    {
        characterNamesText[teamIndex].text = playerList[teamIndex].team[charIndex].characterName;
        abilityText[teamIndex].text = playerList[teamIndex].team[charIndex].characterAbilityName + ": " + playerList[teamIndex].team[charIndex].characterAbility;
        currentMobility[teamIndex].text = "" + playerList[teamIndex].team[charIndex].characterMobility;
        colectedStonesText[teamIndex].text = "" +  playerList[teamIndex].collectedStones;
        cooldownText[teamIndex].text = "" +  playerList[teamIndex].team[charIndex].cooldownTimer;
    }

    // Method to instantiate characters in the game based on player data
    private void PlaceCharacters()
    {
        foreach (Player player in playerList)
        {
            foreach (Characters character in player.team)
            {
                for (int i = 0; i < characterPrefabs.Count; i++)
                {
                    if (character.characterID == i)
                    {
                        // Convertir la posición de celda en posición del mundo
                        Vector3 worldPosition = tilemap.CellToWorld(player.startPosition) + cellCenterOffset();
                        // Instanciar el prefab en la posición del mundo
                        character.characterGO = Instantiate(characterPrefabs[i], worldPosition, Quaternion.identity);
                        character.characterGO.name = character.characterName;
                        character.Position = worldPosition;
                        character.currentCell = player.startPosition;
                    }
                }
            }
        }
    }
    // Method to select a character based on button clicks
    public void SelectCharacter()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (currentPlayer == playerList[0]  && !player1Move )
        {
            if (clickedButton.name == "Char0")
            {
                selectedCharacter = playerList[0].team[0];
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                SetSpecificText(0,0);
            }
            else if (clickedButton.name == "Char1")
            {
                selectedCharacter = playerList[0].team[1];
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                SetSpecificText(0,1);
            }
            else if (clickedButton.name == "Char2")
            {
                selectedCharacter = playerList[0].team[2];
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                SetSpecificText(0,2);
            }
        }
        else if (currentPlayer == playerList[1] && !player2Move)
        {
            if (clickedButton.name == "Char3")
            {
                selectedCharacter = playerList[1].team[0];
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                SetSpecificText(1,0);
            }
            else if (clickedButton.name == "Char4")
            {
                selectedCharacter = playerList[1].team[1];
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                SetSpecificText(1,1);
            }
            else if (clickedButton.name == "Char5")
            {
                selectedCharacter = playerList[1].team[2];
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                SetSpecificText(1,2);
            }
        }
        else if (totalPlayers >= 3)
        {
            if (currentPlayer == playerList[2]  && !player3Move)
            {
                if (clickedButton.name == "Char6")
                {
                    selectedCharacter = playerList[2].team[0];
                    currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                    SetSpecificText(2,0);
                }
                else if (clickedButton.name == "Char7")
                {
                    selectedCharacter = playerList[2].team[1];
                    currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                    SetSpecificText(2,1);
                }
                else if (clickedButton.name == "Char8")
                {
                    selectedCharacter = playerList[2].team[2];
                    currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                    SetSpecificText(2,2);
                }
            }
        }
        if (totalPlayers == 4)
        {
            if(currentPlayer == playerList[3]  && !player4Move)
            {
                if (clickedButton.name == "Char9")
                {
                    selectedCharacter = playerList[3].team[0];
                    currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                    SetSpecificText(3,0);
                }
                else if (clickedButton.name == "Char10")
                {
                    selectedCharacter = playerList[3].team[1];
                    currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                    SetSpecificText(3,1);
                }
                else if (clickedButton.name == "Char11")
                {
                    selectedCharacter = playerList[3].team[2];
                    currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                    SetSpecificText(3,2);
                }
            }
        }
        LifeUI(currentPlayer, selectedCharacter);
        Debug.Log("Selected Character: " + selectedCharacter.characterName);
    }
    // Method to check for victory conditions
    private void VictoryCondition()
    {
        if (currentPlayer.collectedStones == 3)
        {
            if (currentPlayer.playerIndex == 0)
            {
                p1HasWon = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);                
            }
            else if (currentPlayer.playerIndex == 1)
            {
                p2HasWon = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (currentPlayer.playerIndex == 2)
            {
                p3HasWon = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (currentPlayer.playerIndex == 3)
            {
                p4HasWon = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    // Method to calculate the center offset of a tile cell
    private Vector3 cellCenterOffset()
    {
        Vector3 cellSize = tilemap.cellSize; // Tamaño del tile (ancho, alto, profundidad)
        Vector3 cellCenterOffset = new Vector3(cellSize.x / 2f, cellSize.y / 2f, 0);
        return cellCenterOffset;
    }

    //Buttons

    public void P1MoveButton()
    {
        if (currentPlayer == playerList[0])
        {
            if (currentPlayer.remainingSteps == selectedCharacter.characterMobility)
            {
                player1Move = true;
            }
        }
    }
    public void P2MoveButton()
    {
        if (currentPlayer == playerList[1])
        {
            if (currentPlayer.remainingSteps == selectedCharacter.characterMobility)
            {
                player2Move = true;
            }
        }
    }
    public void P3MoveButton()
    {
        if (currentPlayer == playerList[2])
        {
            if (currentPlayer.remainingSteps == selectedCharacter.characterMobility)
            {
                player3Move = true;
            }
        }
    }
    public void P4MoveButton()
    {
        if (currentPlayer == playerList[3])
        {
            if (currentPlayer.remainingSteps == selectedCharacter.characterMobility)
            {
                player4Move = true;
            }
        }
    }

    // Method to end Player 1's turn and switch to the next player
    public void EndP1Turn()
    {
        if (currentPlayer == playerList[0])
        {
            currentPlayer.remainingSteps = selectedCharacter.characterMobility;
            currentPlayer = playerList[1];
            if (player1Move)
            {
                player1Move = false;
            }
            foreach (Characters character in currentPlayer.team)
            {
                if (character.cooldownTimer > 0)
                {
                    character.cooldownTimer--;
                }
            }
            currentPlayer.turnCounter++;
            P2Button.SetActive(true);
            P1Button.SetActive(false);
        }
    }
    public void EndP2Turn()
    {
        if (totalPlayers == 2)
        {
            if (currentPlayer == playerList[1])
            {
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                currentPlayer = playerList[0];
                if (player2Move)
                {
                    player2Move = false;
                }
                foreach (Characters character in currentPlayer.team)
                {
                    if (character.cooldownTimer > 0)
                    {
                        character.cooldownTimer--;
                    }
                }
                currentPlayer.turnCounter++;
                P1Button.SetActive(true);
                P2Button.SetActive(false);
            }
        }
        else
        {
            if (currentPlayer == playerList[1])
            {
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                currentPlayer = playerList[2];
                if (player2Move)
                {
                    player2Move = false;
                }
                foreach (Characters character in currentPlayer.team)
                {
                    if (character.cooldownTimer > 0)
                    {
                        character.cooldownTimer--;
                    }
                }
                currentPlayer.turnCounter++;
                P3Button.SetActive(true);
                P2Button.SetActive(false);
            }
        }
    }
    public void EndP3Turn()
    {
        if (totalPlayers == 3)
        {
            if (currentPlayer == playerList[2])
            {
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                currentPlayer = playerList[0];
                if (player3Move)
                {
                    player3Move = false;
                }
                foreach (Characters character in currentPlayer.team)
                {
                    if (character.cooldownTimer > 0)
                    {
                        character.cooldownTimer--;
                    }
                }
                currentPlayer.turnCounter++;
                P1Button.SetActive(true);
                P3Button.SetActive(false);
            }
        }
        else
        {
            if (currentPlayer == playerList[2])
            {
                currentPlayer.remainingSteps = selectedCharacter.characterMobility;
                currentPlayer = playerList[3];
                if (player3Move)
                {
                    player3Move = false;
                }
                foreach (Characters character in currentPlayer.team)
                {
                    if (character.cooldownTimer > 0)
                    {
                        character.cooldownTimer--;
                    }
                }
                currentPlayer.turnCounter++;
                P4Button.SetActive(true);
                P3Button.SetActive(false);
            }
        }
    }
    public void EndP4Turn()
    {
        if (currentPlayer == playerList[3])
        {
            currentPlayer.remainingSteps = selectedCharacter.characterMobility;
            currentPlayer = playerList[0];
            if (player4Move)
            {
                player4Move = false;
            }
            foreach (Characters character in currentPlayer.team)
            {
                if (character.cooldownTimer > 0)
                {
                    character.cooldownTimer--;
                }
            }
            currentPlayer.turnCounter++;
            P1Button.SetActive(true);
            P4Button.SetActive(false);
        }
    }

    // Methods to use Players ability
    public void UseP1Ability()
    {
        if (selectedCharacter.cooldownTimer <= 0)
        {
            if (selectedCharacter.abilityID == 0 || selectedCharacter.abilityID == 2 || selectedCharacter.abilityID == 4)
            {
                UseAbility0();
            }
            if (selectedCharacter.abilityID == 1 || selectedCharacter.abilityID == 3)
            {
                scBackground.SetActive(true);
                if (totalPlayers < 4)
                {
                    P4.SetActive(false);
                }
                if (totalPlayers < 3)
                {
                    P3.SetActive(false);
                }
            }
            soundManager.SelectAudio(selectedCharacter.characterID, 1f);
        }
    }
    public void UseP2Ability()
    {
        if (selectedCharacter.cooldownTimer <= 0)
        {
            if (selectedCharacter.abilityID == 0 || selectedCharacter.abilityID == 2 || selectedCharacter.abilityID == 4)
            {
                UseAbility0();
            }
            if (selectedCharacter.abilityID == 1 || selectedCharacter.abilityID == 3)
            {
                scBackground.SetActive(true);
                if (totalPlayers < 4)
                {
                    P4.SetActive(false);
                }
                if (totalPlayers < 3)
                {
                    P3.SetActive(false);
                }
            }
            soundManager.SelectAudio(selectedCharacter.characterID, 1f);
        }
    }
    public void UseP3Ability()
    {
        if (selectedCharacter.cooldownTimer <= 0)
        {
            if (selectedCharacter.abilityID == 0 || selectedCharacter.abilityID == 2 || selectedCharacter.abilityID == 4)
            {
                UseAbility0();
            }
            if (selectedCharacter.abilityID == 1 || selectedCharacter.abilityID == 3)
            {
                scBackground.SetActive(true);
                if (totalPlayers < 4)
                {
                    P4.SetActive(false);
                }
                if (totalPlayers < 3)
                {
                    P3.SetActive(false);
                }
            }
            soundManager.SelectAudio(selectedCharacter.characterID, 1f);
        }
    }
    public void UseP4Ability()
    {
        if (selectedCharacter.cooldownTimer <= 0)
        {
            if (selectedCharacter.abilityID == 0 || selectedCharacter.abilityID == 2 || selectedCharacter.abilityID == 4)
            {
                UseAbility0();
            }
            if (selectedCharacter.abilityID == 1 || selectedCharacter.abilityID == 3)
            {
                scBackground.SetActive(true);
                if (totalPlayers < 4)
                {
                    P4.SetActive(false);
                }
                if (totalPlayers < 3)
                {
                    P3.SetActive(false);
                }
            }
            soundManager.SelectAudio(selectedCharacter.characterID, 1f);
        }
    }
    public void SelectTargetPlayer()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (clickedButton.name == "P1")
        {
            _targetPlayer = playerList[0];
        }
        else if (clickedButton.name == "P2")
        {
            _targetPlayer = playerList[1];
        }
        else if (clickedButton.name == "P3")
        {
            _targetPlayer = playerList[2];
        }
        else if (clickedButton.name == "P4")
        {
            _targetPlayer = playerList[3];
        }
        for (int i = 0; i < 3; i++)
        {
            targetCharactersImages[i].sprite = _targetPlayer.team[i].characterImage;
        }
    }
    public void SelectTargetCharacter()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        if (clickedButton.name == "C1")
        {
            UseAbility1(_targetPlayer, _targetPlayer.team[0]);
        }
        else if (clickedButton.name == "C2")
        {
            UseAbility1(_targetPlayer, _targetPlayer.team[1]);
        }
        else if (clickedButton.name == "C3")
        {
            UseAbility1(_targetPlayer, _targetPlayer.team[2]);
        }
        StartCoroutine(DesactivarObjeto(scBackground));
    }
    private IEnumerator DesactivarObjeto(GameObject objeto)
    {
        yield return new WaitForSeconds(0.2f);
        objeto.SetActive(false);
    }

    //TRAPS

    private void SendToStartTrap()
    {
        Vector3 worldPosition = tilemap.CellToWorld(currentPlayer.startPosition) + cellCenterOffset();
        selectedCharacter.characterGO.transform.position = worldPosition;
        selectedCharacter.currentCell = currentPlayer.startPosition;
        selectedCharacter.Position = worldPosition;
    }
    private void StoneTrap()
    {
        if (currentPlayer.collectedStones > 0)
        {
            currentPlayer.collectedStones--;
            colectedStonesText[currentPlayer.playerIndex].text = "" +  currentPlayer.collectedStones;
        } 
    }
    private void CooldownTrap()
    {
        selectedCharacter.cooldownTimer = selectedCharacter.characterCooldown;
        cooldownText[currentPlayer.playerIndex].text = "" +  selectedCharacter.cooldownTimer;
    }

    //Abilities

    private void UseAbility0()
    {
        StartCoroutine(Ability0());
    }
    IEnumerator Ability0()
    {
        currentPlayer.isProtected = true;
        int playerIndex = currentPlayer.playerIndex;
        int playerTurn = currentPlayer.turnCounter;
        Debug.Log($"Bool activado en turno {playerTurn}");
        selectedCharacter.cooldownTimer = selectedCharacter.characterCooldown;
        cooldownText[currentPlayer.playerIndex].text = "" +  selectedCharacter.cooldownTimer;

        yield return new WaitUntil(() => playerList[playerIndex].turnCounter >= playerTurn + 3);

        playerList[playerIndex].isProtected = false;
        Debug.Log($"Bool desactivado en turno {playerList[playerIndex].turnCounter}");
    }
    private void UseAbility1(Player targetPlayer, Characters targetCharacter)
    {
        if (!targetPlayer.isProtected)
        {
            targetCharacter.characterLifePoints -= 100;
            if (targetCharacter.characterLifePoints <= 0)
            {
                Vector3 worldPosition = tilemap.CellToWorld(targetPlayer.startPosition) + cellCenterOffset();
                targetCharacter.characterGO.transform.position = worldPosition;
                targetCharacter.currentCell = targetPlayer.startPosition;
                targetCharacter.Position = worldPosition;
                targetCharacter.characterLifePoints = 300;
            }
        }
        LifeUI(targetPlayer, targetCharacter);
        Debug.Log($"{targetCharacter.characterName} life points: {targetCharacter.characterLifePoints}");
        selectedCharacter.cooldownTimer = selectedCharacter.characterCooldown;
        cooldownText[currentPlayer.playerIndex].text = "" +  selectedCharacter.cooldownTimer;
    }
    private void UseAbility2()
    {
        
    }
    private void UseAbility3()
    {
        
    }
    private void UseAbility4()
    {
        
    }

    //Others

    // Method to update the life UI based on character's life points
    private void LifeUI(Player player, Characters character)
    {
        if (character.characterLifePoints == 300)
        {
            switch (player.playerIndex)
            {
                case 0:
                    foreach (Image image in P1CharacterLife)
                    {
                        image.sprite = Resources.Load<Sprite>("FH");
                    }
                    break;
                case 1:
                    foreach (Image image in P2CharacterLife)
                    {
                        image.sprite = Resources.Load<Sprite>("FH");
                    }
                    break;
                case 2:
                    foreach (Image image in P3CharacterLife)
                    {
                        image.sprite = Resources.Load<Sprite>("FH");
                    }
                    break;
                case 3:
                    foreach (Image image in P4CharacterLife)
                    {
                        image.sprite = Resources.Load<Sprite>("FH");
                    }
                    break;
            }
        }
        else if (character.characterLifePoints == 250)
        {
            switch (player.playerIndex)
            {
                case 0:
                    P1CharacterLife[2].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 1:
                    P2CharacterLife[2].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 2:
                    P3CharacterLife[2].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 3:
                    P4CharacterLife[2].sprite = Resources.Load<Sprite>("HH");
                    break;
            }
        }
        else if (character.characterLifePoints == 200)
        {
            switch (player.playerIndex)
            {
                case 0:
                    P1CharacterLife[2].sprite = Resources.Load<Sprite>("EH");
                    P1CharacterLife[1].sprite = Resources.Load<Sprite>("FH");
                    break;
                case 1:
                    P2CharacterLife[2].sprite = Resources.Load<Sprite>("EH");
                    P2CharacterLife[1].sprite = Resources.Load<Sprite>("FH");
                    break;
                case 2:
                    P3CharacterLife[2].sprite = Resources.Load<Sprite>("EH");
                    P3CharacterLife[1].sprite = Resources.Load<Sprite>("FH");
                    break;
                case 3:
                    P4CharacterLife[2].sprite = Resources.Load<Sprite>("EH");
                    P4CharacterLife[1].sprite = Resources.Load<Sprite>("FH");
                    break;
            }
        }
        else if (character.characterLifePoints == 150)
        {
            switch (player.playerIndex)
            {
                case 0:
                    P1CharacterLife[1].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 1:
                    P2CharacterLife[1].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 2:
                    P3CharacterLife[1].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 3:
                    P4CharacterLife[1].sprite = Resources.Load<Sprite>("HH");
                    break;
            }
        }
        else if (character.characterLifePoints == 100)
        {
            switch (player.playerIndex)
            {
                case 0:
                    P1CharacterLife[1].sprite = Resources.Load<Sprite>("EH");
                    P1CharacterLife[2].sprite = Resources.Load<Sprite>("EH");
                    break;
                case 1:
                    P2CharacterLife[1].sprite = Resources.Load<Sprite>("EH");
                    P2CharacterLife[2].sprite = Resources.Load<Sprite>("EH");
                    break;
                case 2:
                    P3CharacterLife[1].sprite = Resources.Load<Sprite>("EH");
                    P3CharacterLife[2].sprite = Resources.Load<Sprite>("EH");
                    break;
                case 3:
                    P4CharacterLife[1].sprite = Resources.Load<Sprite>("EH");
                    P4CharacterLife[2].sprite = Resources.Load<Sprite>("EH");
                    break;
            }
        }
        else if (character.characterLifePoints == 50)
        {
            switch (player.playerIndex)
            {
                case 0:
                    P1CharacterLife[0].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 1:
                    P2CharacterLife[0].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 2:
                    P3CharacterLife[0].sprite = Resources.Load<Sprite>("HH");
                    break;
                case 3:
                    P4CharacterLife[0].sprite = Resources.Load<Sprite>("HH");
                    break;
            }
        }
        
    }

}
