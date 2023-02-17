using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject mainball;
    public GameObject spawnedball;
    public AI_Controller ai1;
    public AI_Controller ai2;

    Vector3 createPosition;

    TapToStart tos;

    private void Start()
    {

        tos = GameObject.Find("StartScreen").GetComponent<TapToStart>();
        spawnball();

       

       
    }

    //Function to spawn and set the new ball active in the AI_Controllers
    public void spawnball()
    {

        createPosition = RandomPointInBounds(gameObject.GetComponent<BoxCollider>().bounds);

        spawnedball = Instantiate(mainball, createPosition, Quaternion.identity);
        spawnedball.SetActive(true);

        tos.ballSpawnScript = this;
        
        
    }


    public void spawnPlayers()
    {

        GameControl.instance.SpawnPlayers(); 


        GameControl.instance.Player.GetComponent<AI_Controller>().ball = spawnedball;

        GameControl.instance.Computer.GetComponent<AI_Controller>().ball = spawnedball;

        GameControl.instance.Player.GetComponent<AI_Controller>().rb = spawnedball.GetComponent<Rigidbody>();

        GameControl.instance.Computer.GetComponent<AI_Controller>().rb = spawnedball.GetComponent<Rigidbody>();

        GameControl.instance.MainBall = spawnedball;

    }

    public Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
