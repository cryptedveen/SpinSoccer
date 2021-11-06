using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject mainball;
    public GameObject spawnedball;
    public AI_Controller ai1;
    public AI_Controller ai2;

    private void Start()
    {
        spawnball();
    }

    //Function to spawn and set the new ball active in the AI_Controllers
    public void spawnball()
    {
        spawnedball = Instantiate(mainball, gameObject.transform.position, Quaternion.identity);
        spawnedball.SetActive(true);

        ai1.ball = spawnedball;
        ai2.ball = spawnedball;
    }
}
