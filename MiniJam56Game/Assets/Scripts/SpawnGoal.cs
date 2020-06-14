using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoal : MonoBehaviour
{
    public GameObject goal;

    // Define time ranges for spawning
    private float maxDelay = 6;
    private float minDelay = 2;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(SpawnGoals());
    }

    IEnumerator SpawnGoals() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            Instantiate(goal, transform.position, transform.rotation);
        }
    }
}
