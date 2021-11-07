using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{

    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject GameControl;

    [SerializeField] public GameObject AI1;
    [SerializeField] public GameObject AI2;

    private AI_Controller ai1, ai2;

    void Awake()
    {
        HUD.gameObject.SetActive(false);
        ai1 = AI1.GetComponent<AI_Controller>();
        ai2 = AI2.GetComponent<AI_Controller>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1 || Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            HUD.gameObject.SetActive(true);

            ai1.isMoving = true;
            ai2.isMoving = true;


        }
    }
}
