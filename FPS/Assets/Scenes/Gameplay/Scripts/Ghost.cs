using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    float movementSpeed;

    void Start()
    {
        movementSpeed = 5f;
    }

    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * movementSpeed);
    }
}
