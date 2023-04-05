using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.AI;
using System.Linq.Expressions;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;

    [HideInInspector]public int PlayerMoney = 200;

    public TextMeshProUGUI MoneyUI;

    public GameObject UICharacterSpawner, UIChar;

    public AudioSource audioSource;

    [SerializeField] public int Team1Score;
    [SerializeField] public int Team2Score;

    public Text UI1Score, UI2Score;

    [HideInInspector] public GameObject MainBall;

    public GameObject Player1Spawner, Player2Spawner;

    public GameObject playerPrefab, aiSpawned;
    public GameObject[] aiPrefabs;

    public GameObject Player, Computer, lockObject;

    int CharacterNumber = 1, playerModelCount;

    public bool playerAvailable;

    Transform mainPlayer;

    private void Awake()
    {


        instance = this;

        f_SaveLoadData();

        DontDestroyOnLoad(gameObject);

        f_UpdateMoney();



        playerModelCount = playerPrefab.transform.GetChild(0).childCount;

        lockObject = GameObject.Find("Lock");
        lockObject.GetComponent<Image>().enabled = false;


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

        playerAvailable = true;

        lockObject.GetComponent<Image>().enabled = false;

        

        UIChar = Instantiate(playerPrefab, UICharacterSpawner.transform.position, Quaternion.identity);
        UIChar.transform.parent = UICharacterSpawner.transform;

        Destroy(UIChar.GetComponent<NavMeshAgent>());
        Destroy(UIChar.GetComponent<Rigidbody>());
        Destroy(UIChar.GetComponent<AI_Controller>());
        Destroy(UIChar.GetComponent<CapsuleCollider>());

        GameObject currentMesh = UIChar.transform.GetChild(0).GetChild(CharacterNumber).gameObject;
        currentMesh.SetActive(true);

        GameObject.Find("CharacterName").gameObject.GetComponent<TextMeshProUGUI>().text = currentMesh.GetComponent<isLocked>().charName;

        if (currentMesh.GetComponent<isLocked>().locked == true)
        {
            currentMesh.GetComponent<SkinnedMeshRenderer>().material = new Material(Shader.Find("Universal Render Pipeline/Simple Lit"));

            lockObject.GetComponent<Image>().enabled = true;

            playerAvailable = false;
        }


       


    }


    public void NextCharacter()
    {
        if (CharacterNumber < playerModelCount - 1)
        {
            CharacterNumber++;
            ChangePlayer();
        }
        else
        {
            CharacterNumber = 1;
            ChangePlayer();
        }
            
    }

    public void PrevCharacter()
    {
        if(CharacterNumber > 1)   //One because the mesh starts from 1 element as 0 element is armature
        {   
            CharacterNumber--;
            ChangePlayer();
        }
        else
        {

            CharacterNumber = playerModelCount - 1;


            ChangePlayer();
        }

    }

    public void SpawnPlayers()
    {
        int aiNumber = Random.Range(0, aiPrefabs.Length);

        aiSpawned = aiPrefabs[aiNumber];

        Player = Instantiate(playerPrefab, Player2Spawner.transform.position, new Quaternion(0, 1, 0, 0) );
        
        Player.transform.GetChild(0).GetChild(CharacterNumber).gameObject.SetActive(true);

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

    public void f_SaveLoadData()
    {
        print(PlayerPrefs.GetInt("i_Money"));

        if (PlayerPrefs.HasKey("i_Money"))
        {
            PlayerPrefs.SetInt("i_Money", PlayerMoney);
        }
        else
        {
            PlayerMoney = PlayerPrefs.GetInt("i_Money");
        }

        
    }

    public void f_SaveMoney()
    {
        
        
        PlayerPrefs.SetInt("i_Money", PlayerMoney);
        

        PlayerPrefs.Save();
    }

    public void f_UpdateMoney()
    {
        MoneyUI.SetText(PlayerMoney.ToString());
    }

    private void OnApplicationQuit()
    {
        f_SaveMoney();
    }
}
