using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Araba_Kodu : MonoBehaviour
{
    public WheelCollider FrontLeftWheel, FrontRightWheel,RearLeftWheel,RearRightWheel;

    public float motorh�z�,donmehizi;


    void Update()
    {
        RearRightWheel.motorTorque = motorh�z� * Input.GetAxis("Vertical");
        RearLeftWheel.motorTorque = motorh�z� * Input.GetAxis("Vertical");
        FrontRightWheel.steerAngle = donmehizi * Input.GetAxis("Horizontal");
        FrontLeftWheel.steerAngle = donmehizi * Input.GetAxis("Horizontal"); 
    }
}
