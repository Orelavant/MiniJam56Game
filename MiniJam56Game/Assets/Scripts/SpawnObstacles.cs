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
    private bool isInBulletZone1 = false;
    private bool isInBulletZone2 = false;
    private float bulletZone1 = 5;
    private float bulletZone2 = -5f;
    private float stationaryTime = 3;
    private float warningTime = 2;
    public GameObject bullet;

    // Start is called before the first frame update
    private void Start() {
        // Attaching objects to references
        gameManager = GameObject.Find("EventSystem");
        player = GameObject.Find("player");

        StartCoroutine(SpawnObstacle());
        /*StartCoroutine(TrackPlayer());*/
    }

    private void Update() {
        /*// Tracking player position
        if (player.transform.position.y > bulletZone2 && player.transform.position.y < 0) {
            isInBulletZone1 = false;
            isInBulletZone2 = true;
        }
        if (player.transform.position.y < bulletZone1 && player.transform.position.y > 0) {
            isInBulletZone1 = true;
            isInBulletZone2 = false;
        }*/
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            gameManager.GetComponent<GameManager>().PlayAudio(cannonSound);
            yield return new WaitForSeconds(cannonDelay);
            Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(minHeight, maxHeight), 0f), transform.rotation);
        }
    }

    IEnumerator TrackPlayer() {
        while (true) {
            if (isInBulletZone1) {
                yield return new WaitForSeconds(stationaryTime + warningTime);
                Instantiate(bullet, new Vector3(transform.position.x, Random.Range(0, bulletZone1), 0f), transform.rotation);
            }
            if (isInBulletZone2) {
                yield return new WaitForSeconds(stationaryTime + warningTime);
                Instantiate(bullet, new Vector3(transform.position.x, Random.Range(0, bulletZone1), 0f), transform.rotation);
            }
        }
    }
}
