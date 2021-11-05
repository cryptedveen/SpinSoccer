using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI_Controller : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] public GameObject ball;
    [SerializeField] public BoxCollider leftleg;
    [SerializeField] public BoxCollider rightleg;
    [SerializeField] public float force = 300f;
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
            Vector3 ballposi = getballposition();

            animator.SetFloat("Speed", 10f);

            if (Vector3.Distance(destination, ballposi) > 1.0f)
            {
                destination = ballposi;
                myNavMeshAgent.destination = destination;
            }
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == ball)
        {
            animator.SetFloat("Speed", 0f);
            Debug.Log("Animation Logged");
            int min = 0, max = 4;
            int randomnumber = Random.Range(min, max);
            Debug.Log(randomnumber);
            Vector3 collisionPoint = col.ClosestPoint(transform.position);
            Vector3 dir = transform.position - collisionPoint;
            dir = -dir.normalized;

            switch (randomnumber)
            {
                case 1:
                    rb.AddForce(dir * force * 0.5f);
                    Debug.Log("Case1");
                    break;
                case 2:
                    rb.AddForce(dir * force * 1.5f);
                    Debug.Log("Case2");
                    break;
                default:
                    rb.AddForce(dir * force * 1f);
                    Debug.Log("Case3");
                    break;
            }
        }
    }


    Vector3 getballposition()
    {
        return ball.transform.position;
    }
}
