using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoal : MonoBehaviour
{
    private int spawnRate = 9;
    private int initialDelay = 4;

    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", initialDelay, spawnRate);
    }

    void Spawn() {
        Instantiate(goal, transform.position, transform.rotation);
    }
}
