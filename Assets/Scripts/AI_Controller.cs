using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class AI_Controller : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] public GameObject ball;
    //[SerializeField] private BoxCollider leftleg;
    //[SerializeField] private BoxCollider rightleg;
    [SerializeField] private float force = 100f;
    [SerializeField] public bool isMoving = false;
    
    
    public Rigidbody rb ;
    private NavMeshAgent myNavMeshAgent;
    private Vector3 destination;
    public float runspeed = 0;

    // Start is called before the first frame update
    void Start()
    {

        myNavMeshAgent = GetComponent<NavMeshAgent>();
        destination = myNavMeshAgent.destination;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!rb) rb = ball.GetComponent<Rigidbody>();

        transform.LookAt(ball.transform);
        MovetoBall();
        
    }


    void MovetoBall()
    {
        if (isMoving && ball)
        {
           
            
                Vector3 ballposi = getballposition();

                animator.SetFloat("Speed", 10f);

                //'Vector3.Distance' function finds the distance between two given transforms.
                if (Vector3.Distance(destination, ballposi) > 1.0f)
                {
                    destination = ballposi;
                    float runspeed = Random.Range(200, 300);

                    myNavMeshAgent.speed = runspeed * Time.deltaTime;
                    myNavMeshAgent.destination = destination;
                }
            
        }
    }


    //OnTrigger is for Collider and OnCollisionEnter is for collision. 
    /* void OnTriggerEnter(Collider col)
     {
         if (col.gameObject == ball)
         {
             animator.SetFloat("Speed", 0f);

             //Random Number generation for switch case.
             int min = 0, max = 4;
             int randomnumber = Random.Range(min, max);

            //collision point vector from point of contact.
             Vector3 collisionPoint = col.ClosestPoint(transform.position);
             Vector3 dir = transform.position - collisionPoint;
             dir = -dir.normalized;

             //To randomise the force added on collision.
             switch (randomnumber)
             {
                 case 1:
                     rb.AddForce(dir * force * 0.5f);
                     //Debug.Log("Case1");
                     break;
                 case 2:
                     rb.AddForce(dir * force * 1.5f);
                     //Debug.Log("Case2");
                     break;
                 default:
                     rb.AddForce(dir * force * 1f);
                     //Debug.Log("Case3");
                     break;
             }
         }*/

    void OnCollisionEnter(Collision collision)
    {
        if (!rb) rb = ball.GetComponent<Rigidbody>();
        if (collision.gameObject == ball)
        {
            
            int min = 0, max = 4;
            int randomnumber = Random.Range(min, max);
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = dir.normalized;

            switch (randomnumber)
            {
                case 1:
                    rb.AddForce(dir * force * 0.5f);
                    break;
                case 2:
                    rb.AddForce(dir * force * 0.75f);
                    break;
                default:
                    rb.AddForce(dir * force * 1f);
                    break;
            }
        }
    }



    //Function to Get Position of ball. 
    Vector3 getballposition()
    {
        return ball.transform.position;
    }

    

   
}
