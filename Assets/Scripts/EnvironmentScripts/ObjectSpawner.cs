using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    [SerializeField] private float maxTimer = 0.0f;
    private float spawnTimer;          // Stores the delay between obstacle spawns

    [SerializeField] private List<GameObject> obstacles;        // Stores the obstacles which could be spawned

    [SerializeField] private MeshCollider spawnArea;
    private List<int> weightedValues = new List<int>() {0,0,0, 1,1,1, 2,2};

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
        // Decreases the timer by deltaTime every frame
        spawnTimer -= Time.deltaTime;

        // Checks if the timer is 0 or less than 0
        if (spawnTimer <= 0.0f && !GlobalVariables.isGameOver) {

            float spawnX, spawnY;

            int pickObstacle = weightedValues[UnityEngine.Random.Range(0, weightedValues.Count-1)];

            GameObject obstacleToSpawn = obstacles[pickObstacle];

            string obstacleType = obstacleToSpawn.GetComponent<ObjectController>().objectType;

            spawnX = UnityEngine.Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);

            if (obstacleType == "tall" || obstacleType == "special") {

                spawnY = spawnArea.bounds.min.y + (obstacleToSpawn.GetComponent<Transform>().localScale.y / 2);

            } else {

                spawnY = UnityEngine.Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y) + 1.5f;

            }

            Instantiate(obstacleToSpawn, new Vector3(spawnX, spawnY), Quaternion.identity);

            spawnTimer = maxTimer;

        }
        
    }
}
