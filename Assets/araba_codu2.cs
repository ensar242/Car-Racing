using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class araba_codu2 : MonoBehaviour
{
    [SerializeField] WheelCollider frontRigth;
    [SerializeField] WheelCollider frontleft;
    [SerializeField] WheelCollider backRigth;
    [SerializeField] WheelCollider backleft;

    [SerializeField] Transform frontRigthTransform;
    [SerializeField] Transform frontleftTransform;
    [SerializeField] Transform backRigthTransform;
    [SerializeField] Transform backleftTransform;//11.27 dk da kaldýn ensar devamýný getir

    public float acceleration = 500f;
    public float breakingforce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceeration = 0f;
    private float currentBreakingforce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate()
    {
        currentAcceeration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Escape))
        {
            currentBreakingforce = breakingforce;
        }
        else
        {
            currentBreakingforce = 0f;
        }
        frontRigth.motorTorque = currentAcceeration;
        frontleft.motorTorque = currentAcceeration;

        frontRigth.brakeTorque= currentBreakingforce; 
        frontleft.brakeTorque = currentBreakingforce;   
        backleft.brakeTorque=-currentBreakingforce;
        backRigth.brakeTorque-=currentBreakingforce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontleft.steerAngle = currentTurnAngle;
        frontRigth.steerAngle = currentTurnAngle;

        UpdateWheel(frontleft, frontleftTransform);
        UpdateWheel(frontRigth, frontRigthTransform);
        UpdateWheel(backleft, backleftTransform);
        UpdateWheel(backRigth, backRigthTransform);
    }
   void UpdateWheel (WheelCollider col, Transform trans ) 
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose( out position, out rotation );

        trans.position = position;
        trans.rotation = rotation;

    }
}
