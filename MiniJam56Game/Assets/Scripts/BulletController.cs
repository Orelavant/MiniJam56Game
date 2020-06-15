using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    private GameObject obstacleSpawner;
    private float speed;
    private int bulletModifier = 2;

    private void Start() {
        obstacleSpawner = GameObject.Find("obstacleSpawnManager");
        obstacleSpawner.GetComponent<SpawnObstacles>().bulletSpeed += bulletModifier;
        speed = obstacleSpawner.GetComponent<SpawnObstacles>().bulletSpeed;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -11) {
            Destroy(gameObject);
        }
    }
}
