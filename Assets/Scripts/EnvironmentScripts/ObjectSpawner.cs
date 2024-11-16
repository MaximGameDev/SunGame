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

    [SerializeField] private MeshCollider mesh;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        float spawnX, spawnY;
        
        // Decreases the timer by deltaTime every frame
        spawnTimer -= Time.deltaTime;

        // Checks if the timer is 0 or less than 0
        if (spawnTimer <= 0.0f) {

            spawnX = UnityEngine.Random.Range(mesh.bounds.min.x, mesh.bounds.max.x);
            spawnY = UnityEngine.Random.Range(mesh.bounds.min.y, mesh.bounds.max.y);

            int pickObstacle = (int)UnityEngine.Random.Range(1, 6);
            
            // Switch statement for spawning obstacles at a set probability
            switch (pickObstacle) {

                case 1:
                    Instantiate(obstacles[0], new Vector3(spawnX, spawnY), Quaternion.identity);
                break;

                case 2:
                    Instantiate(obstacles[0], new Vector3(spawnX, spawnY), Quaternion.identity);
                break;

                case 3:
                    Instantiate(obstacles[1], new Vector3(spawnX, spawnY), Quaternion.identity);
                break;

                case 4:
                    Instantiate(obstacles[1], new Vector3(spawnX, spawnY), Quaternion.identity);
                break;

                case 5:
                    Instantiate(obstacles[2], new Vector3(spawnX, spawnY), Quaternion.identity);
                break;

            }

            Debug.Log("Obj to spawn: " + pickObstacle);

            spawnTimer = maxTimer;

            Debug.Log("Spawn Timer: " + spawnTimer);

        }
        
    }
}
