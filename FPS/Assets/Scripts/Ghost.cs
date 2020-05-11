using System;
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
    float detectionRange;

    bool turningAround;

    Quaternion targetQuaternion;

    public static Action<GameObject, float> CheckPlayerProximity;
    public static Action OnPlayerDetected;

    void Start()
    {
        minPositionLimit = -48f;
        maxPositionLimit = 12f;
        movementSpeed = 5f;
        rotationSpeed = 5f;
        rotationRange = 90f;
        rotationTarget = UnityEngine.Random.Range(-(rotationRange / 2), rotationRange / 2);
        detectionRange = 10f;

        turningAround = false;

        targetQuaternion = Quaternion.Euler(0, rotationTarget, 0);
    }

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * movementSpeed);

        if (!turningAround)
            CheckPositionLimits();

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetQuaternion, Time.deltaTime * rotationSpeed);
        if (transform.localRotation == targetQuaternion)
            UpdateRotationTarget();
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
            //turningAround = true;
            //
            //Vector3 newRotation = transform.localRotation.eulerAngles;
            //newRotation.y -= 180f;
            //targetQuaternion = Quaternion.Euler(newRotation);

            Destroy(this.gameObject);
        }
    }

    void UpdateRotationTarget()
    {
        if (turningAround)
            turningAround = false;

        rotationTarget = UnityEngine.Random.Range(-(rotationRange / 2), rotationRange / 2);
        targetQuaternion = Quaternion.Euler(0, rotationTarget, 0);
    }
}