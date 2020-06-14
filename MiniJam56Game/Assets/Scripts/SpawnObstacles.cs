using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    private float maxHeight = 0;
    private float minHeight = -5;
    private int spawnRate = 5;
    private int initialDelay = 2;

    public GameObject obstacle;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("SpawnObstacle", initialDelay, spawnRate);
    }

    void SpawnObstacle() {
        Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), 0f), transform.rotation);
    }
}
