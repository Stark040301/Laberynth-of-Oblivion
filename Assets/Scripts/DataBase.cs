using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class stores and manages character data for the game
public class DataBase : MonoBehaviour
{
    // Lists to store characters for each team
    public static List<Characters> AnimeTeam = new List<Characters>();
    public static List<Characters> FilmTeam = new List<Characters>();
    public static List<Characters> DisneyTeam = new List<Characters>();
    public static List<Characters> MarvelTeam = new List<Characters>();

    // Initialize all characters with their attributes
    public static void InitializeCharacters()
    {
        // Anime Team
        AnimeTeam.Add(new Characters(
            0,
            0,
            "Uchiha Madara",
            "Anime",
            "Susano'o", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "Madara Uchiha fue uno de los fundadores de la aldea de la Hoja y del mundo ninja.", 
            5, 
            5,
            Resources.Load<Sprite>("A1"),
            Resources.Load<Sprite>("IA1")
        ));
        
        AnimeTeam.Add(new Characters(
            1,
            1,
            "Frieza", 
            "Anime",
            "Cañón de la muerte", 
            "Inflige un daño de un corazón en el enemigo seleccionado.", 
            "Frieza es un tirano galáctico que busca la dominación del universo.", 
            4, 
            7,
            Resources.Load<Sprite>("A2"),
            Resources.Load<Sprite>("IA2")
        ));

        AnimeTeam.Add(new Characters(
            2,
            2,
            "Sosuke Aizen", 
            "Anime",
            "Hipnosis Total", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "Aizen es un ex capitán de la Sociedad de Almas que busca convertirse en un dios.", 
            5, 
            3,
            Resources.Load<Sprite>("A3"),
            Resources.Load<Sprite>("IA3")
        ));

        AnimeTeam.Add(new Characters(
            3,
            3,
            "Ryomen Sukuna", 
            "Anime",
            "Expansión de dominio: Altar Malévolo", 
            "Inflige un daño de un corazón en el enemigo seleccionado.", 
            "Sukuna es conocido como el Rey de las Maldiciones, una entidad temible y poderosa.", 
            4, 
            5,
            Resources.Load<Sprite>("A4"),
            Resources.Load<Sprite>("IA4")
        ));

        AnimeTeam.Add(new Characters(
            4,
            4,
            "Kibutsuji Muzan", 
            "Anime",
            "Arte de Sangre Demoníaca: Biokinesis", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "Muzan es el progenitor de los demonios y el principal antagonista de los cazadores de demonios.", 
            3, 
            3,
            Resources.Load<Sprite>("A5"),
            Resources.Load<Sprite>("IA5")
        ));

        // Film Team
        FilmTeam.Add(new Characters(
            5,
            1,
            "Lord Voldemort", 
            "Film",
            "Avada Kedavra", 
            "Inflige un daño de un corazón en el enemigo seleccionado.", 
            "El mago oscuro más temido en la historia del mundo mágico.", 
            4, 
            7,
            Resources.Load<Sprite>("F1"),
            Resources.Load<Sprite>("IF1")
        ));

        FilmTeam.Add(new Characters(
            6,
            0,
            "Darth Vader", 
            "Film",
            "Estrangulamiento de la Fuerza", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "El temible aprendiz de Darth Sidious, que busca el control de la galaxia.", 
            5, 
            5,
            Resources.Load<Sprite>("F2"),
            Resources.Load<Sprite>("IF2")
        ));

        FilmTeam.Add(new Characters(
            7,
            2,
            "Sauron", 
            "Film",
            "Dominación del anillo de poder", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "Sauron es un señor oscuro que busca dominar la Tierra Media.", 
            5, 
            3,
            Resources.Load<Sprite>("F3"),
            Resources.Load<Sprite>("IF3")
        ));

        FilmTeam.Add(new Characters(
            8,
            4,
            "Dracula", 
            "Film",
            "Mordida Vampírica", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "El vampiro más famoso, que busca extender su reinado de terror.", 
            4, 
            5,
            Resources.Load<Sprite>("F4"),
            Resources.Load<Sprite>("IF4")
        ));

        FilmTeam.Add(new Characters(
            9,
            3,
            "Pennywise", 
            "Film",
            "Cambiaformas", 
            "Inflige un daño de un corazón en el enemigo seleccionado.", 
            "Una entidad cósmica que se alimenta del miedo de sus víctimas.", 
            5, 
            5,
            Resources.Load<Sprite>("F5"),
            Resources.Load<Sprite>("IF5")
        ));

        // Disney Team
        DisneyTeam.Add(new Characters(
            10,
            1,
            "Scar", 
            "Disney",
            "LLamado de las hienas", 
            "Convoca una emboscada de hienas para atacar un enemigo, infligiendo un corazón de daño.", 
            "El león traidor que tomó el trono de la Roca del Rey.", 
            4, 
            7,
            Resources.Load<Sprite>("D1"),
            Resources.Load<Sprite>("ID1")
        ));

        DisneyTeam.Add(new Characters(
            11,
            3,
            "Malefica", 
            "Disney",
            "Maldición de espinas", 
            "Envuelve a un enemigo en espinas, infligiendo un corazón de daño al enemigo seleccionado", 
            "La poderosa hechicera que busca venganza contra quienes la traicionaron.", 
            4, 
            5,
            Resources.Load<Sprite>("D2"),
            Resources.Load<Sprite>("ID2")
        ));

        DisneyTeam.Add(new Characters(
            12,
            0,
            "Hades", 
            "Disney",
            "Llamas del Inframundo", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "El dios del inframundo que busca derrocar a los dioses del Olimpo.", 
            5, 
            5,
            Resources.Load<Sprite>("D3"),
            Resources.Load<Sprite>("ID3")
        ));

        DisneyTeam.Add(new Characters(
            13,
            4,
            "Ursula", 
            "Disney",
            "Tentáculos atadores", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "La bruja del mar que hace tratos peligrosos con los desafortunados.", 
            5, 
            5,
            Resources.Load<Sprite>("D4"),
            Resources.Load<Sprite>("ID4")
        ));

        DisneyTeam.Add(new Characters(
            14,
            2,
            "Jafar", 
            "Disney",
            "Hipnosis Viperina", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "El gran visir de Agrabah que busca el poder absoluto.", 
            5, 
            3,
            Resources.Load<Sprite>("D5"),
            Resources.Load<Sprite>("ID5")
        ));

        // Marvel Team
        MarvelTeam.Add(new Characters(
            15,
            0,
            "Magneto", 
            "Marvel",
            "Barrera Magnética", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "El maestro del magnetismo que lucha por la supremacía mutante.", 
            5, 
            5,
            Resources.Load<Sprite>("M1"),
            Resources.Load<Sprite>("IM1")
        ));

        MarvelTeam.Add(new Characters(
            16,
            2,
            "Loki", 
            "Marvel",
            "Maestría Ilusoria", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "El dios nórdico del engaño y la trampa.", 
            5, 
            3,
            Resources.Load<Sprite>("M2"),
            Resources.Load<Sprite>("IM2")
        ));

        MarvelTeam.Add(new Characters(
            17,
            1,
            "Thanos", 
            "Marvel",
            "Chasquido del infinito", 
            "Usa el guante del infinito para infligir un daño de un corazón sobre un enemigo seleccionado.", 
            "El titán loco que busca equilibrar el universo.", 
            4, 
            7,
            Resources.Load<Sprite>("M3"),
            Resources.Load<Sprite>("IM3")
        ));

        MarvelTeam.Add(new Characters(
            18,
            4,
            "Ultron", 
            "Marvel",
            "Corrupción Viral", 
            "Protege al equipo de ataques enemigos durante tres turnos consecutivos.", 
            "La inteligencia artificial que busca la extinción de la humanidad.", 
            5, 
            5,
            Resources.Load<Sprite>("M4"),
            Resources.Load<Sprite>("IM4")
        ));

        MarvelTeam.Add(new Characters(
            19,
            3,
            "Dr. Doom", 
            "Marvel",
            "Ultimatum", 
            "Inflige un daño de un corazón en el enemigo seleccionado.", 
            "El tirano de Latveria, un genio en ciencia y magia.", 
            6, 
            4,
            Resources.Load<Sprite>("M5"),
            Resources.Load<Sprite>("IM5")
        ));
    }
}
