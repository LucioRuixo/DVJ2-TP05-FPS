using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    public int score;

    float rayDistance;

    Camera mainCamera;

    Ray ray;

    RaycastHit raycastHit;

    void Start()
    {
        life = 100;
        score = 0;

        rayDistance = 1000f;
    }

    void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out raycastHit, rayDistance);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.yellow);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
            life -= 50;
    }
}
