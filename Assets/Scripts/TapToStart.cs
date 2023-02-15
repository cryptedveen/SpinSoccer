using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{

    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject numOne,numTwo,numThree;
    [SerializeField] private GameObject UICharacter;

    private AI_Controller ai1, ai2;

    void Awake()
    {
        HUD.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1 || Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            HUD.gameObject.SetActive(true);

            UICharacter.gameObject.SetActive(false);

            GameControl.instance.Player.GetComponent<AI_Controller>().isMoving = true;

            GameControl.instance.Computer.GetComponent<AI_Controller>().isMoving = true;

        }
    }
}
