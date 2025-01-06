using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Players> AnimeTeam = new List<Players>();
    public List<Players> FilmTeam = new List<Players>();
    public List<Players> DisneyTeam = new List<Players>();
    public List<Players> MarvelTeam = new List<Players>();
    void Start()
    {
        
    }

    private void InitializeCharacters()
    {
        AnimeTeam.Add(new Players("Uchiha Madara", "Susano'o", 5, 5));
        AnimeTeam.Add(new Players("Frieza", "Death Cannon", 4, 7));
        AnimeTeam.Add(new Players("Aizen Sōsuke", "Complete Hypnosis", 5, 3));
        AnimeTeam.Add(new Players("Sukuna Ryōmen", "Domain Expansion: Malevolent Shrine", 4, 5));
        AnimeTeam.Add(new Players("Kibutsuji Muzan", "Blood Demon Art: Biokinesis", 3, 3));

        FilmTeam.Add(new Players("Lord Voldemort", "Avada Kedavra", 4, 7));
        FilmTeam.Add(new Players("Darth Vader", "Force Choke", 5, 5));
        FilmTeam.Add(new Players("Sauron", "The One Ring Domination", 5, 3));
        FilmTeam.Add(new Players("Dracula", "Vampire Bite", 4, 5));
        FilmTeam.Add(new Players("Pennywise", "Shapeshift", 5, 5));

        DisneyTeam.Add(new Players("Scar", "Call of the Hyenas", 4, 7));
        DisneyTeam.Add(new Players("Maleficent", "Curse of Thornes", 4, 5));
        DisneyTeam.Add(new Players("Hades", "Underworld Flames", 5, 5));
        DisneyTeam.Add(new Players("Ursula", "Binding Tentacles", 5, 5));
        DisneyTeam.Add(new Players("Jafar", "Serpent's Hypnosis", 5, 3));

        MarvelTeam.Add(new Players("Magneto", "Magnetic Barrier", 5, 5));
        MarvelTeam.Add(new Players("Loki", "Illusion Mastery", 5, 3));
        MarvelTeam.Add(new Players("Thanos", "Infinity Gauntlet Snap", 4, 7));
        MarvelTeam.Add(new Players("Ultron", "Viral Corruption", 5, 5));
        MarvelTeam.Add(new Players("Dr. Doom", "Doom's Ultimatum", 6, 4));
    }
}
