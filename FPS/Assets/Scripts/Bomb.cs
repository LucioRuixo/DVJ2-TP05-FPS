using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float detectionRange;

    public static Action<GameObject, float> CheckPlayerProximity;
    public static Action OnPlayerDetected;

    void Start()
    {
        detectionRange = 5f;
    }

    void Update()
    {
        CheckPlayerProximity(this.gameObject, detectionRange);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(this.gameObject);
    }
}