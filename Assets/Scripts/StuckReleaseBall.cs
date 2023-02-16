using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckReleaseBall : MonoBehaviour
{

    Vector3 deltaPosi;
    Vector3 currentPosi;
    Vector3 diff;
    float timer;
    Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        currentPosi = transform.position;
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
       

        if (timer < 0)
        {
            deltaPosi = currentPosi;
            currentPosi = transform.position;
            releaseball();
        }

       

    }

    void releaseball()
    {
        
        diff = deltaPosi - currentPosi;
        
      

        if (diff.Equals(Vector3.zero))
        {
            //Debug.Log("Ball Force Added");
            m_Rigidbody.AddForce(transform.up * 500);
            
        }

        timer = 5f;
    }
}
