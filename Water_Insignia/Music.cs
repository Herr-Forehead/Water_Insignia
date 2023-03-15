using System;
using Raylib_cs;


public class Musik
{
    static Music MainTheme = Raylib.LoadMusicStream("MainTheme.mp3");
    static Music ChasingDaybreak = Raylib.LoadMusicStream("ChasingDaybreak.mp3");
    static Music HeritorsOfArcadia = Raylib.LoadMusicStream("HeritorsOfArcadia.mp3");
    static Music gameOverSerious6b = Raylib.LoadMusicStream("gameOver(Serious6b).mp3");
    static Music death = Raylib.LoadMusicStream("death.mp3");

    public static void PlayMusic(string scene)
    {

        if (scene == "start")
        {
            Raylib.PlayMusicStream(MainTheme);
            Raylib.UpdateMusicStream(MainTheme);
        }
        else if (scene == "plrTurn" || scene == "nmyTurn")
        {
            Raylib.StopMusicStream(MainTheme);
            Raylib.StopMusicStream(death);
            Raylib.PlayMusicStream(ChasingDaybreak);
            Raylib.UpdateMusicStream(ChasingDaybreak);
        }
        else if (scene == "death")
        {
            Raylib.StopMusicStream(ChasingDaybreak);
            Raylib.PlayMusicStream(death);
            Raylib.UpdateMusicStream(death);
        }
        else if (scene == "gameOver")
        {
            Raylib.StopMusicStream(ChasingDaybreak);
            Raylib.PlayMusicStream(gameOverSerious6b);
            Raylib.UpdateMusicStream(gameOverSerious6b);
        }
        else if (scene == "end")
        {
            Raylib.StopMusicStream(ChasingDaybreak);
            Raylib.PlayMusicStream(HeritorsOfArcadia);
        }
    }

}
