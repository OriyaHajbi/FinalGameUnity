using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    public GameObject CanvasObject;

    public static Winning singelton;

    bool isWinning = false;
    public winningScreen winningScreen;
    public GameObject gameScreen;

    void Start()
    {
        singelton = this;

    }

    public void Update()
    {
        if (Shooting.enemyKilled == 2 && ChestMotion.keyTaked && !isWinning)
        {
            winning();
            Shooting.enemyKilled = 0;
            ChestMotion.keyTaked = false;
            isWinning = true;
        }
    }

    public void winning()
    {

        Time.timeScale = 0; // Pause the Game
        //DisableCanvas();
        winningScreen.Setup();
        gameScreen.SetActive(false);
    }

    void DisableCanvas()
    {
        //CanvasObject.SetActive(false);
    }
}
