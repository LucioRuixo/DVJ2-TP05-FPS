using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        float ghostTimer;
        float ghostTimerTarget;
        float bombTimer;
        float bombTimerTarget;
        float roadTileSize;

        public GameObject bombPrefab;
        public GameObject ghostPrefab;

        public List<GameObject> road = new List<GameObject>();

        void Start()
        {
            ghostTimer = bombTimer = 0f;
            ghostTimerTarget = 5f;
            bombTimerTarget = 10f;
            roadTileSize = 12f;

            InstantiateEnemy(bombPrefab);
            InstantiateEnemy(ghostPrefab);
        }

        void Update()
        {
            ghostTimer += Time.deltaTime;
            bombTimer += Time.deltaTime;
            if (ghostTimer >= ghostTimerTarget)
            { 
                InstantiateEnemy(ghostPrefab);
                ghostTimer -= ghostTimerTarget;
            }
            if (bombTimer >= bombTimerTarget)
            {
                InstantiateEnemy(bombPrefab);
                bombTimer -= bombTimerTarget;
            }
        }

        void InstantiateEnemy(GameObject prefab)
        {
            Transform randomRoadTile = road[(int)Random.Range(0, road.Count)].transform;
            float initialX = randomRoadTile.position.x - Random.Range(-(roadTileSize / 2), roadTileSize / 2);
            float initialY = randomRoadTile.position.y;
            float initialZ = randomRoadTile.position.z - Random.Range(-(roadTileSize / 2), roadTileSize / 2);
            Vector3 initialPosition = new Vector3(initialX, initialY, initialZ);
            Quaternion initialRotation = Quaternion.Euler(new Vector3(0, Random.Range(1, 360), 0));

            Instantiate(prefab, initialPosition, initialRotation);
        }
    }
}