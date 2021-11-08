using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameControl : MonoBehaviour
{

    [SerializeField] public int Team1Score;
    [SerializeField] public int Team2Score;

    public Text UI1Score, UI2Score;

    public GameObject MainBall;
    //public BoxCollider T1C1, T1C2, T2C1, T2C2;

    public void scoreUpdate()
    {
        UI1Score.text = Team1Score.ToString();

        UI2Score.text = Team2Score.ToString();

    }

}
