using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneManager : MonoBehaviour
    // This class manages the end scene and displays the victory message.
{
    [SerializeField] private TMP_Text victoryText;

    void Start()
    {
        Victory();
    }

    // Method to display the victory message based on the winning player
    private void Victory()
    {
        if (PlayerHandler.p1HasWon)
        {
            victoryText.text = " El jugador 1 ha ganado el juego. Gracias por jugar!";
        }
        else if (PlayerHandler.p2HasWon)
        {
            victoryText.text = " El jugador 2 ha ganado el juego. Gracias por jugar!";
        }
        else if (PlayerHandler.p3HasWon)
        {
            victoryText.text = " El jugador 3 ha ganado el juego. Gracias por jugar!";
        }
        else if (PlayerHandler.p4HasWon)
        {
            victoryText.text = " El jugador 4 ha ganado el juego. Gracias por jugar!";
        }
    }
}
