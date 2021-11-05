using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{

    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject GameControl;

    [SerializeField] public GameObject AI1;
    [SerializeField] public GameObject AI2;


    void Start()
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


        }
    }
}
