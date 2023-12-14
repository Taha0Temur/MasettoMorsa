using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    public WheelCollider OnSolCol;
    public WheelCollider OnSagCol;
    public WheelCollider ArkaSolCol;
    public WheelCollider ArkaSagCol;

    public GameObject OnSol;
    public GameObject OnSag;
    public GameObject ArkaSol;
    public GameObject ArkaSag;

    public float maxMotorGucu;
    public float maxDonusAcisi;
    public float motor;

    public float frenGucu = 50000000000000000000.0f; // Fren gücü deðeri

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FrenYap();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            FrenKaldir();
        }
    }
    void FrenKaldir()
    {
        ArkaSolCol.brakeTorque = 0;
        ArkaSagCol.brakeTorque = 0;
    }

    private void FixedUpdate()
    {
        motor = maxMotorGucu * Input.GetAxis("Vertical");
        float donus = maxDonusAcisi * Input.GetAxis("Horizontal");

        OnSolCol.steerAngle = OnSagCol.steerAngle = donus;
        ArkaSagCol.motorTorque = motor;
        ArkaSolCol.motorTorque = motor;

        SanalTeker();
    }

    void SanalTeker()
    {
        Quaternion rot;
        Vector3 pos;
        OnSolCol.GetWorldPose(out pos, out rot);
        OnSol.transform.position = pos;
        OnSol.transform.rotation = rot;

        OnSagCol.GetWorldPose(out pos, out rot);
        OnSag.transform.position = pos;
        OnSag.transform.rotation = rot;

        ArkaSolCol.GetWorldPose(out pos, out rot);
        ArkaSol.transform.position = pos;
        ArkaSol.transform.rotation = rot;

        ArkaSagCol.GetWorldPose(out pos, out rot);
        ArkaSag.transform.position = pos;
        ArkaSag.transform.rotation = rot;
    }

    void FrenYap()
    {
        ArkaSolCol.motorTorque = 0;
        ArkaSagCol.motorTorque = 0;

        ArkaSolCol.brakeTorque = frenGucu;
        ArkaSagCol.brakeTorque = frenGucu;
    }

}
