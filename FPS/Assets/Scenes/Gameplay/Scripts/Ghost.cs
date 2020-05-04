using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    float minPositionLimit;
    float maxPositionLimit;
    float movementSpeed;
    float rotationSpeed;
    float rotationRange;
    float rotationTarget;

    bool turningAround;

    Quaternion targetQuaternion;

    void Start()
    {
        minPositionLimit = -48f;
        maxPositionLimit = 12f;
        movementSpeed = 5f;
        rotationSpeed = 5f;
        rotationRange = 90f;
        rotationTarget = Random.Range(-(rotationRange / 2), rotationRange / 2);

        turningAround = false;

        targetQuaternion = Quaternion.Euler(0, rotationTarget, 0);
    }

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * movementSpeed);

        if (!turningAround)
            CheckPositionLimits();

        transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, Time.deltaTime * rotationSpeed);
        if (transform.rotation == targetQuaternion)
        {
            if (turningAround)
                turningAround = false;
            
            rotationTarget = Random.Range(-(rotationRange / 2), rotationRange / 2);
            targetQuaternion = Quaternion.Euler(0, rotationTarget, 0);
        }

        Debug.Log(targetQuaternion);
    }

    void CheckPositionLimits()
    {
        bool offLimitsX = false;
        bool offLimitsZ = false;

        if (transform.position.x < minPositionLimit || transform.position.x > maxPositionLimit)
            offLimitsX = true;

        if (transform.position.z < minPositionLimit || transform.position.z > maxPositionLimit)
            offLimitsZ = true;

        if (offLimitsX || offLimitsZ)
        {
            turningAround = true;

            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.y -= 180f;
            targetQuaternion = Quaternion.Euler(newRotation);
        }
    }
}
