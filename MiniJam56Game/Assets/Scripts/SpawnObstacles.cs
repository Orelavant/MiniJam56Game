using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    //References
    public AudioClip cannonSound;
    public GameObject obstacle;
    private GameObject gameManager;
    private GameObject player;

    // Define spawn range for obstacles
    private float maxHeight = 0;
    private float minHeight = -5;

    // Define time ranges
    private float maxDelay = 6;
    private float minDelay = 2;

    // How long it takes for cannon to arrive on screen after hearing sound
    private float cannonDelay = 0.7f;

    // Variables used to keep player from staying in the same area too often
    private bool spawningBullet1 = false;
    private bool spawningBullet2 = false;
    private bool isInBulletZone1 = false;
    private bool isInBulletZone2 = false;
    private float bulletZone1 = 5;
    private float bulletZone2 = -5f;
    private float stationaryTime = 5;
    private float warningTime = 1;
    public int bulletSpeed = 8;
    public GameObject bullet;
    public GameObject warningSign;

    // Start is called before the first frame update
    private void Start() {
        // Attaching objects to references
        gameManager = GameObject.Find("EventSystem");
        player = GameObject.Find("player");

        StartCoroutine(SpawnObstacle());
    }

    private void Update() {
        // Tracking player position
        if (player.transform.position.y < bulletZone1 && player.transform.position.y > 0) {
            isInBulletZone1 = true;
            isInBulletZone2 = false;
        }
        if (player.transform.position.y > bulletZone2 && player.transform.position.y < 0) {
            isInBulletZone1 = false;
            isInBulletZone2 = true;
        }

        // Preventing stationary tactics
        if (isInBulletZone1 && !spawningBullet1) {
            StartCoroutine(SpawnBullet1());
        }
        if (isInBulletZone2 && !spawningBullet2) {
            StartCoroutine(SpawnBullet2());
        }
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            gameManager.GetComponent<GameManager>().PlayAudio(cannonSound);
            yield return new WaitForSeconds(cannonDelay);
            Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), 0f), transform.rotation);
        }
    }

    IEnumerator SpawnBullet1() {
        spawningBullet1 = true;
        yield return new WaitForSeconds(stationaryTime);
        if (isInBulletZone1) {
            float spawnBulletPosition = player.transform.position.y;
            Instantiate(warningSign, new Vector3(7.7f, spawnBulletPosition, 0f), transform.rotation);
            yield return new WaitForSeconds(warningTime);
            Destroy(GameObject.Find("warningSign(Clone)"));
            Instantiate(bullet, new Vector3(transform.position.x, spawnBulletPosition, 0f), transform.rotation);
        }
        spawningBullet1 = false;
    }

    IEnumerator SpawnBullet2() {
        spawningBullet2 = true;
        yield return new WaitForSeconds(stationaryTime);
        if (isInBulletZone2) {
            float spawnBulletPosition = player.transform.position.y;
            Instantiate(warningSign, new Vector3(7.7f, spawnBulletPosition, 0f), transform.rotation);
            yield return new WaitForSeconds(warningTime);
            Destroy(GameObject.Find("warningSign(Clone)"));
            Instantiate(bullet, new Vector3(transform.position.x, spawnBulletPosition, 0f), transform.rotation);
        }
        spawningBullet2 = false;
    }
}
