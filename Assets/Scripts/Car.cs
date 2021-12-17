using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

[System.Serializable]
public class VisualWheelsInfo
{
    public GameObject leftWheel;
    public GameObject rightWheel;
}
public class Car : MonoBehaviour
{
    [Header("AxleInfos and Visual Wheels Info should be in respective order")]
    public List<AxleInfo> axleInfos;
    public List<VisualWheelsInfo> visualWheelsInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider, GameObject wheel)
    {
        Transform visualWheel = wheel.transform;

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        //visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        if (axleInfos.Count != visualWheelsInfos.Count)
        {
            Debug.LogError("Visual Wheels and wheel colliders are not equal");
            return;
        }
        for (int i=0;i< axleInfos.Count;i++)
        {
            if (axleInfos[i].steering)
            {
                axleInfos[i].leftWheel.steerAngle = steering;
                axleInfos[i].rightWheel.steerAngle = steering;
            }
            if (axleInfos[i].motor)
            {
                axleInfos[i].leftWheel.motorTorque = motor;
                axleInfos[i].rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfos[i].leftWheel, visualWheelsInfos[i].leftWheel);
            ApplyLocalPositionToVisuals(axleInfos[i].rightWheel, visualWheelsInfos[i].rightWheel);
        }
    }
}