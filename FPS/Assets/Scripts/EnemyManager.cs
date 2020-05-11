using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;

    void Start()
    {
        Bomb.CheckPlayerProximity = Ghost.CheckPlayerProximity = CheckPlayerProximity;

        Bomb.OnPlayerDetected = Bomb_OnPlayerDetected;

        Ghost.OnPlayerDetected = Ghost_OnPlayerDetected;
    }

    void CheckPlayerProximity(GameObject enemy,  float detectionRange)
    {
        Vector3 distanceVector = player.transform.position - enemy.transform.position;
        float sqrDistance = distanceVector.sqrMagnitude;

        if (sqrDistance < detectionRange * detectionRange)
        {
            if (enemy.tag == "Bomb")
                Bomb_OnPlayerDetected();
            
            if (enemy.tag == "Ghost")
                Ghost_OnPlayerDetected();
        }
    }

    void Bomb_OnPlayerDetected()
    {

    }

    void Ghost_OnPlayerDetected()
    {

    }
}