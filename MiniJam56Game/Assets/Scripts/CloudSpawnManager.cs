using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnManager : MonoBehaviour {

    private float maxHeight = 4;
    private float minHeight = -4;

    private int spawnRate = 3;
    private int initialDelay = 0;

    public GameObject cloud;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", initialDelay, spawnRate);
    }

    void Spawn() {
        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight)), transform.rotation);
    }
}
