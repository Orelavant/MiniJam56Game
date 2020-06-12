using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    [SerializeField] private int spawnRate = 5;
    private int initialDelay = 2;
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("SpawnObstacle", initialDelay, spawnRate);
    }

    // Update is called once per frame
    void Update() {
        // TODO: Set spawn position randomly.
    }

    void SpawnObstacle() {
        // TODO: Set rotation of obstacle
        Instantiate(obstacle, transform.position, transform.rotation);
    }
}
