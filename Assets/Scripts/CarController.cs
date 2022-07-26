using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float MaxMotorTorque;
    public float MaxSteeringAngle;

    public float Acceleration;
    public float Brake;

    public GameObject SteeringWheel;
    public Rigidbody rb;
    public float ScaledSpeed;

    [SerializeField]
    private bool _drivingForward;
    [SerializeField]
    private float _scaleMultiplier;
    
    private Vector3 _oldPosition;

    private void Awake()
    {
        if(_scaleMultiplier == 0)
        {
            _scaleMultiplier = 1;
        }
    }
    private void Update()
    {
        _drivingForward = GameObject.Find("GearBoxManager").GetComponent<GearBoxManager>().DrivingForward;
    }

    public void FixedUpdate()
    {
        //float motor = MaxMotorTorque * Input.GetAxis("Vertical");
        float motor = MaxMotorTorque * Acceleration;
        //float steering = MaxSteeringAngle * Input.GetAxis("Horizontal");
        float steering = MaxSteeringAngle * SteeringWheel.GetComponent<SteeringWheel>().OutPut();

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            VisualWheelCollider(axleInfo.leftWheel);
            VisualWheelCollider(axleInfo.rightWheel);
        }
        ActualSpeed();
    }

    public void VisualWheelCollider(WheelCollider collider)
    {
        if(collider.transform.childCount == 0)
        {
            return;
        }
        Transform visualWheel = collider.transform.GetChild(0);
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }


    public void AccelerationInput(float input) 
    {
        if (_drivingForward == true)
        {
            Acceleration = input;
        }
        if(_drivingForward == false)
        {
            Acceleration = -input;
        }
    }
    
    public void BrakeInput()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.brakeTorque = 1f;
                axleInfo.rightWheel.brakeTorque = 1f;
            }
        }
    }

    public void BrakeInput2()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.brakeTorque = 0f;
                axleInfo.rightWheel.brakeTorque = 0f;
            }
        }
    }

    private void ActualSpeed()
    {
        float scaledVelocity = (rb.velocity.magnitude * 3.6f) * _scaleMultiplier;
        if (scaledVelocity >= 0.1)
        {
            ScaledSpeed = scaledVelocity;
        }
        else
        {
            ScaledSpeed = 0;
        }
    }
}
[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
