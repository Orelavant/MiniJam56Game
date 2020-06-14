using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject obstacle;

    // Define spawn range for obstacles
    private float maxHeight = 0;
    private float minHeight = -5;

    // Define time ranges
    private float maxDelay = 6;
    private float minDelay = 2;

    // Start is called before the first frame update
    private void Start() {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), 0f), transform.rotation);
        }
    }
}
