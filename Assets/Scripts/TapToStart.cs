using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{

    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject numOne, numTwo, numThree;
    [SerializeField] private GameObject UICharacter;

    public SpawnBall ballSpawnScript;

    private AI_Controller ai1, ai2;


    bool gameStarted = false;

    [SerializeField] VariableJoystick joystick;
    void Awake()
    {
        HUD.gameObject.SetActive(false);

    }




    // Update is called once per frame
    void Update()
    {

        if (gameStarted == false)
        {
            if (joystick.Horizontal > 0 || joystick.Horizontal < 0) 
            {
                if (GameControl.instance.playerAvailable)     //This checks if character is unlocked
                {
                    gameStarted = true;
                    ballSpawnScript.spawnPlayers();   //Check in Spawn Ball Script

                    gameObject.SetActive(false);
                    HUD.gameObject.SetActive(true);

                    UICharacter.gameObject.SetActive(false);

                    GameControl.instance.Player.GetComponent<AI_Controller>().isMoving = true;

                    GameControl.instance.Computer.GetComponent<AI_Controller>().isMoving = true;
                }
               

            }
        }
        
    }
}
