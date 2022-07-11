using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    public GameObject CanvasObject;

    public static GameOver singelton;


    public GameOverScreen gameOverScreen;

    void Start()
    {
        singelton = this;

    }

    public void gameOver()
    {
        //UnityEditor.EditorApplication.isPlaying = false; // Exit from the game

        Time.timeScale = 0; // Pause the Game
        //DisableCanvas();
        gameOverScreen.Setup();
    }

    void DisableCanvas()
    {
        CanvasObject.SetActive(false);
    }
}
