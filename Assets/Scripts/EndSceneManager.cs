using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text victoryText;
    
    void Start()
    {
        Victory();
    }

    void Update()
    {
        
    }

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
