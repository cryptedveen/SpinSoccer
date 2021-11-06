using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI_Controller : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] public GameObject ball;
    [SerializeField] private BoxCollider leftleg;
    [SerializeField] private BoxCollider rightleg;
    [SerializeField] private float force = 300f;
    [SerializeField] public bool isMoving = false;
    
    
    private Rigidbody rb ;
    private NavMeshAgent myNavMeshAgent;
    private Vector3 destination;


    // Start is called before the first frame update
    void Start()
    {

        myNavMeshAgent = GetComponent<NavMeshAgent>();

        rb = ball.GetComponent<Rigidbody>();

        destination = myNavMeshAgent.destination;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (ball.gameObject)
            {
                Vector3 ballposi = getballposition();

                animator.SetFloat("Speed", 10f);

                //'Vector3.Distance' function finds the distance between two given transforms.
                if (Vector3.Distance(destination, ballposi) > 1.0f)
                {
                    destination = ballposi;
                    myNavMeshAgent.destination = destination;
                }
            }
        }
    }


    //OnTrigger is for Collider and OnCollisionEnter is for collision. 
    void OnTriggerEnter(Collider col)
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
        }
    }

    //Function to Get Position of ball. 
    Vector3 getballposition()
    {
        return ball.transform.position;
    }

    void setMoveTrue (bool mover)
    {
        isMoving = mover;
    }

}
