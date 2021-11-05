using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWall : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public int max;
    public int min;
    int randomnumber;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            randomnumber = Random.Range(min, max);
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;

            switch (randomnumber)
            {
                case 1:
                    rb.AddForce(dir * force * 0.5f);
                    break;
                case 2:
                    rb.AddForce(dir * force * 1.5f);
                    break;
                default:
                    rb.AddForce(dir * force * 1f);
                    break;
            }
        }
    }
}
