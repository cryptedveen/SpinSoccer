using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionScore : MonoBehaviour
{

    public BoxCollider T1C1, T1C2, T2C1, T2C2;
    public GameControl gamescores;
    BoxCollider collidedbox;
    GameObject post1, post2, post3, post4, ScoreController, BallSpawner;
    SpawnBall spawncontrol;
    public GameObject particleprefab, particleprefabinstance;
    ParticleSystem particles1, particles2;

    Vector3 spawnPosition;

    private void Awake()
    {
        //Get Gamobjects from scene automatically after spawn.
        post1 = GameObject.Find("Post1");
        post2 = GameObject.Find("Post2");
        post3 = GameObject.Find("Post3");
        post4 = GameObject.Find("Post4");
        BallSpawner = GameObject.Find("BallSpawner");
        ScoreController = GameObject.Find("__GAME_MANAGER__");


        


        //Get the relevant components/scripts needed from the game objects after spawn. 
        T1C1 = post1.GetComponent<BoxCollider>();
        T1C2 = post3.GetComponent<BoxCollider>();
        T2C1 = post2.GetComponent<BoxCollider>();
        T2C2 = post4.GetComponent<BoxCollider>();
        spawncontrol = BallSpawner.GetComponent<SpawnBall>();
        gamescores = ScoreController.GetComponent<GameControl>();

        particleprefabinstance = Instantiate(particleprefab, spawncontrol.transform.position, Quaternion.identity);

      //  particles1 = particleprefabinstance.
      //  particles2 = particleprefabinstance.GetComponentInChildren<ParticleSystem>();

        particles1 = particleprefabinstance.transform.GetChild(0).GetComponentInChildren<ParticleSystem>();
        particles2 = particleprefabinstance.transform.GetChild(1).GetComponentInChildren<ParticleSystem>();
    }

    void destroyparticles()
        {
        
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.transform.position = spawncontrol.transform.position;


        spawnPosition = spawncontrol.RandomPointInBounds(BallSpawner.GetComponent<BoxCollider>().bounds);
        

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        gameObject.transform.position = spawnPosition;
        gameObject.SetActive(true);

        particles1.Stop();
        particles2.Stop();

    }

    private void OnTriggerEnter(Collider collideractive)
    {
        collidedbox = collideractive.gameObject.GetComponent<BoxCollider>(); //AI Goals
        if (gameObject)
        {
            if (collidedbox == T1C1 || collidedbox == T1C2)
            {
                gamescores.Team1Score = gamescores.Team1Score + 1;
                
                Debug.Log(gamescores.Team1Score);

                gamescores.scoreUpdate();

                gameObject.SetActive(false);

                particles1.Play();
                particles2.Play();

                Invoke("destroyparticles", 1f);

               


            }

            if (collidedbox == T2C1 || collidedbox == T2C2) //Player Goals
            {
                gamescores.Team2Score = gamescores.Team2Score + 1;
                
                Debug.Log(gamescores.Team2Score);

                gamescores.scoreUpdate();

                gameObject.SetActive(false);

                particles1.Play();
                particles2.Play();

                Invoke("destroyparticles", 1f);

                GameControl.instance.PlayerMoney += 50;
                GameControl.instance.f_UpdateMoney();
                GameControl.instance.f_SaveMoney();
            }
        }

       


        /* MUST READ 
          
         Have Commented the following coz i tried this method but since it calls for the overall collison of game object
        and not the collider I shifted to OntriggerEnter method where you can get the collider with which the ball is interacting
        and not TerrainHeightmapSyncControl overall collision If you want to use this below method, GridLayout need to find if
        the contact point is indexer box collider, which is async bigger process. so use the above method 

        Dont forget to set box collider to trigger when using this method.
        
        */



        /* private void OnCollisionEnter(Collision collision)
         {
             collidedbox = collision.gameObject.GetComponent<BoxCollider>();
             if (gameObject)
             {
                 if (collidedbox == T1C1 || collidedbox == T1C2)
                 {
                     gamescores.Team1Score = gamescores.Team1Score + 1;
                     Destroy(gameObject);
                     Debug.Log(gamescores.Team1Score);

                     spawncontrol.spawnball();

                 }

                 if (collidedbox == T2C1 || collidedbox == T2C2)
                 {
                     gamescores.Team2Score = gamescores.Team2Score + 1;
                     Destroy(gameObject);
                     Debug.Log(gamescores.Team2Score);

                     spawncontrol.spawnball();
                 }
             }
         }*/
    }
}
