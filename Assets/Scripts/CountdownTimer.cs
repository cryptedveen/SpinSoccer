using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] float TotalTime = 60;
    int seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalTime > 1)

        {
            TotalTime -= Time.deltaTime;
            seconds = Mathf.FloorToInt(TotalTime % 60);

            gameObject.GetComponent<TextMeshProUGUI>().text = seconds.ToString();
        }



    }
}
