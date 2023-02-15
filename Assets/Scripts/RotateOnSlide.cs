using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnSlide : MonoBehaviour
{

    //Joystick placed in UI
    public VariableJoystick joystick;
    public float speed;
    bool isInverted = false;
    void Update()
    {
        

        float move = joystick.Horizontal;

        if (isInverted)
        {
            //The x value of joystick movement controls the rtation of the goal posts. 
            Quaternion target = Quaternion.Euler(0f, move * speed * Time.deltaTime, 0f).normalized;
            transform.rotation = target * transform.rotation;
        }
        else
        {
            //The x value of joystick movement controls the rtation of the goal posts. 
            Quaternion target = Quaternion.Euler(0f, -move * speed * Time.deltaTime, 0f).normalized;
            transform.rotation = target * transform.rotation;
        }
       


    }
}
