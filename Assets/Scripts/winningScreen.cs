using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winningScreen : MonoBehaviour
{
    public Text goldCoinGO;
    public Text EnemyKilledGO;

    void Update()
    {
        


    }
    public void Setup()
    {
        gameObject.SetActive(true);
        goldCoinGO.text = "Gold Coins: " + PickCoin.pickedCoins;
        EnemyKilledGO.text = "Enemy Killed: " + Shooting.enemyKilled;
    }

    public void RestartButton()
    {
        //SceneManager.LoadScene("Game");
        //goldCoinGO.text = "Clicked";
    }

    public void ExitButton()
    {

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();


    }
}
