using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnSlide : MonoBehaviour
{

    //Joystick placed in UI
    public FixedJoystick joystick;
    public float speed;
    void Update()
    {


        float move = joystick.Horizontal;



        //The x value of joystick movement controls the rtation of the goal posts. 
        Quaternion target = Quaternion.Euler(0f, -move * speed, 0f).normalized;
        transform.rotation = target * transform.rotation ;


    }
}
