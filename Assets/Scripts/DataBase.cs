using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public static List<Characters> AnimeTeam = new List<Characters>();
    public static List<Characters> FilmTeam = new List<Characters>();
    public static List<Characters> DisneyTeam = new List<Characters>();
    public static List<Characters> MarvelTeam = new List<Characters>();
    void Start()
    {
        
    }

    public static void InitializeCharacters()
{
    // Anime Team
    AnimeTeam.Add(new Characters(
        "Uchiha Madara", 
        "Susano'o", 
        "Protege al equipo de ataques enemigos durante dos turnos consecutivos.", 
        "Madara Uchiha fue uno de los fundadores de la aldea de la Hoja y del mundo ninja.", 
        5, 
        5,
        Resources.Load<Sprite>("A1"),
        Resources.Load<Sprite>("EI")
    ));
    
    AnimeTeam.Add(new Characters(
        "Frieza", 
        "Cañón de la muerte", 
        "Inflige un daño de un corazón en el enemigo seleccionado a más de 5 casillas de radio.", 
        "Frieza es un tirano galáctico que busca la dominación del universo.", 
        4, 
        7,
        Resources.Load<Sprite>("A2"),
        Resources.Load<Sprite>("EI")
    ));

    AnimeTeam.Add(new Characters(
        "Sosuke Aizen", 
        "Hipnosis Total", 
        "Te permite controlar una ficha de un oponente seleccionado en su siguiente turno.", 
        "Aizen es un ex capitán de la Sociedad de Almas que busca convertirse en un dios.", 
        5, 
        3,
        Resources.Load<Sprite>("A3"),
        Resources.Load<Sprite>("EI")
    ));

    AnimeTeam.Add(new Characters(
        "Ryomen Sukuna", 
        "Expansión de dominio: Altar Malévolo", 
        "Despliega una expansión de dominio que daña medio corazón a los enemigos en un área de 4 casillas.", 
        "Sukuna es conocido como el Rey de las Maldiciones, una entidad temible y poderosa.", 
        4, 
        5,
        Resources.Load<Sprite>("A4"),
        Resources.Load<Sprite>("EI")
    ));

    AnimeTeam.Add(new Characters(
        "Kibutsuji Muzan", 
        "Arte de Sangre Demoníaca: Biokinesis", 
        "Regenera medio corazón y lanza látigos de sangre que dañan medio corazón a los enemigos en línea recta de hasta 3 casillas.", 
        "Muzan es el progenitor de los demonios y el principal antagonista de los cazadores de demonios.", 
        3, 
        3,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    // Film Team
    FilmTeam.Add(new Characters(
        "Lord Voldemort", 
        "Avada Kedavra", 
        "Inflige un daño de un corazón en el enemigo seleccionado en línea recta.", 
        "El mago oscuro más temido en la historia del mundo mágico.", 
        4, 
        7,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    FilmTeam.Add(new Characters(
        "Darth Vader", 
        "Estrangulamiento de la Fuerza", 
        "Usa la Fuerza para asfixiar a un enemigo, infligiendo medio corazón y paralizándolo durante 2 turnos.", 
        "El temible aprendiz de Darth Sidious, que busca el control de la galaxia.", 
        5, 
        5,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    FilmTeam.Add(new Characters(
        "Sauron", 
        "Dominación del anillo de poder", 
        "Corrompe la mente de un enemigo, obligándolo a ejercer su voluntad en el siguiente turno.", 
        "Sauron es un señor oscuro que busca dominar la Tierra Media.", 
        5, 
        3,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    FilmTeam.Add(new Characters(
        "Dracula", 
        "Mordida Vampírica", 
        "Muerde a un enemigo dentro de un área de 3 casillas, causándole un daño de un corazón y absorbiendo la mitad como salud.", 
        "El vampiro más famoso, que busca extender su reinado de terror.", 
        4, 
        5,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    FilmTeam.Add(new Characters(
        "Pennywise", 
        "Cambiaformas", 
        "Toma la forma de los peores miedos de un enemigo, reduciendo su movilidad a 1 y cancelando su habilidad por 2 turnos.", 
        "Una entidad cósmica que se alimenta del miedo de sus víctimas.", 
        5, 
        5,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    // Disney Team
    DisneyTeam.Add(new Characters(
        "Scar", 
        "LLamado de las hienas", 
        "Convoca una emboscada de hienas para atacar un enemigo, infligiendo un corazón de daño.", 
        "El león traidor que tomó el trono de la Roca del Rey.", 
        4, 
        7,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    DisneyTeam.Add(new Characters(
        "Malefica", 
        "Maldición de espinas", 
        "Envuelve a un enemigo en espinas, infligiendo medio corazón de daño y reduciendo su movilidad a 1 durante 2 turnos.", 
        "La poderosa hechicera que busca venganza contra quienes la traicionaron.", 
        4, 
        5,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    DisneyTeam.Add(new Characters(
        "Hades", 
        "Llamas del Inframundo", 
        "Desata llamas del inframundo que causan un corazón de daño en un área de 3 casillas y quemaduras de 1/4 de corazón durante 2 turnos.", 
        "El dios del inframundo que busca derrocar a los dioses del Olimpo.", 
        5, 
        5,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    DisneyTeam.Add(new Characters(
        "Ursula", 
        "Tentáculos atadores", 
        "Atrapa a un enemigo con sus tentáculos, infligiendo medio corazón de daño y paralizándolo durante 2 turnos.", 
        "La bruja del mar que hace tratos peligrosos con los desafortunados.", 
        5, 
        5,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    DisneyTeam.Add(new Characters(
        "Jafar", 
        "Hipnosis Viperina", 
        "Te permite controlar una ficha de un oponente seleccionado en su siguiente turno.", 
        "El gran visir de Agrabah que busca el poder absoluto.", 
        5, 
        3,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    // Marvel Team
    MarvelTeam.Add(new Characters(
        "Magneto", 
        "Barrera Magnética", 
        "Crea una barrera magnética que impide todos los ataques y habilidades enemigas durante 2 turnos.", 
        "El maestro del magnetismo que lucha por la supremacía mutante.", 
        5, 
        5,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    MarvelTeam.Add(new Characters(
        "Loki", 
        "Maestría Ilusoria", 
        "Controla la mente de un enemigo, obligándolo a ejercer su voluntad en su siguiente turno.", 
        "El dios nórdico del engaño y la trampa.", 
        5, 
        3,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    MarvelTeam.Add(new Characters(
        "Thanos", 
        "Chasquido del infinito", 
        "Usa el guante del infinito para infligir un daño de un corazón sobre un enemigo seleccionado.", 
        "El titán loco que busca equilibrar el universo.", 
        4, 
        7,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    MarvelTeam.Add(new Characters(
        "Ultron", 
        "Corrupción Viral", 
        "Se infiltra en els sistema de un enemigo, paralizándolo durante 3 turnos.", 
        "La inteligencia artificial que busca la extinción de la humanidad.", 
        5, 
        5,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));

    MarvelTeam.Add(new Characters(
        "Dr. Doom", 
        "Ultimatum", 
        "Desactiva las habilidades de todos los enemigos por 2 turnos y reduce su movilidad en 1. Inflige medio corazón en un enemigo seleccionado.", 
        "El tirano de Latveria, un genio en ciencia y magia.", 
        6, 
        4,
        Resources.Load<Sprite>("EI"),
        Resources.Load<Sprite>("EI")
    ));
}

}
