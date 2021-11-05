using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnSlide : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed;
    void Update()
    {


        float move = joystick.Horizontal;

        Quaternion target = Quaternion.Euler(0f, -move * speed, 0f).normalized;
        transform.rotation = target * transform.rotation ;


    }
}
