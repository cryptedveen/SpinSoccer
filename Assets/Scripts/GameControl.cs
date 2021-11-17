using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameControl : MonoBehaviour
{

    public AudioSource audioSource;

    [SerializeField] public int Team1Score;
    [SerializeField] public int Team2Score;

    public Text UI1Score, UI2Score;

    public GameObject MainBall;
    public GameObject Player1, Player2;
   

public void scoreUpdate()
    {

        UI1Score.text = Team1Score.ToString();

        UI2Score.text = Team2Score.ToString();

        if(Team1Score > 7) { WinScreenShow(); }
        if(Team2Score > 7) { LoseScreenFalse(); }

    }


    private void WinScreenShow()
    {
        Player1.SetActive(false);
        Player2.SetActive(false);
        MainBall.SetActive(false);
    }                     
                          
    private void LoseScreenFalse()
    {                     
        Player1.SetActive(false);
        Player2.SetActive(false);
        MainBall.SetActive(false);

    }

}
