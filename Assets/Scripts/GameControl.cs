using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.AI;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;

    public GameObject UICharacterSpawner, UIChar;

    public AudioSource audioSource;

    [SerializeField] public int Team1Score;
    [SerializeField] public int Team2Score;

    public Text UI1Score, UI2Score;

    [HideInInspector] public GameObject MainBall;

    public GameObject Player1Spawner, Player2Spawner;

    public GameObject playerPrefab, aiSpawned;
    public GameObject[] aiPrefabs;

    public GameObject Player, Computer;

    int CharacterNumber = 0;

    private void Awake()
    {

        instance = this;

        DontDestroyOnLoad(gameObject);



    }
    private void Start()
    {

        ChangePlayer();
    }

    public void ChangePlayer()
    {
        if(UIChar != null)
        {
            Destroy(UIChar);
        }

        UIChar = Instantiate(aiPrefabs[CharacterNumber], UICharacterSpawner.transform.position, Quaternion.identity);
        UIChar.transform.parent = UICharacterSpawner.transform;
        Destroy(UIChar.GetComponent<NavMeshAgent>());
        Destroy(UIChar.GetComponent<Rigidbody>());
        Destroy(UIChar.GetComponent<AI_Controller>());
        Destroy(UIChar.GetComponent<CapsuleCollider>());



    }


    public void NextCharacter()
    {
        if (CharacterNumber < aiPrefabs.Length-1)
        {
            CharacterNumber++;
            ChangePlayer();
        }
        else
        {
            CharacterNumber = 0;
            ChangePlayer();
        }
            
    }

    public void PrevCharacter()
    {
        if(CharacterNumber > 0)
        {
            CharacterNumber--;
            ChangePlayer();
        }
        else
        {
           

            CharacterNumber = aiPrefabs.Length - 1;


            ChangePlayer();
        }

    }

    public void SpawnPlayers()
    {
        int aiNumber = Random.Range(0, aiPrefabs.Length);

        aiSpawned = aiPrefabs[aiNumber];

        Player = Instantiate(aiPrefabs[CharacterNumber], Player2Spawner.transform.position, new Quaternion(0, 1, 0, 0) );
        Computer = Instantiate(aiSpawned, Player1Spawner.transform.position, Quaternion.identity);
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
