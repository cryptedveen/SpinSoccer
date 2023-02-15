using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;


   

    public AudioSource audioSource;

    [SerializeField] public int Team1Score;
    [SerializeField] public int Team2Score;

    public Text UI1Score, UI2Score;

    [HideInInspector] public GameObject MainBall;

    public GameObject Player1Spawner, Player2Spawner;

    public GameObject playerPrefab, aiSpawned;
    public GameObject[] aiPrefabs;

    public GameObject Player, Computer;

    private void Awake()
    {

        instance = this;

        



    }

    public void SpawnPlayers()
    {
        int aiNumber = Random.Range(0, aiPrefabs.Length);

        aiSpawned = aiPrefabs[aiNumber];

        Player = Instantiate(playerPrefab, Player1Spawner.transform.position, Quaternion.identity);
        Computer = Instantiate(aiSpawned, Player2Spawner.transform.position, new Quaternion(0, 1, 0, 0));
    }

    public void scoreUpdate()
    {

        UI1Score.text = Team1Score.ToString();

        UI2Score.text = Team2Score.ToString();

        if(Team1Score > 7) { WinScreenShow(); }
        if(Team2Score > 7) { LoseScreenFalse(); }

    }


    private void WinScreenShow()
    {
        playerPrefab.SetActive(false);
        aiSpawned.SetActive(false);
        MainBall.SetActive(false);
    }                     
                          
    private void LoseScreenFalse()
    {
        playerPrefab.SetActive(false);
        aiSpawned.SetActive(false);
        MainBall.SetActive(false);

    }

}
