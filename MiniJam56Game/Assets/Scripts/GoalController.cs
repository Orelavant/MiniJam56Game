using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalController : MonoBehaviour {

    private int speed = 3;

    private GameObject playerController;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start() { 
        playerController = GameObject.Find("player");
        gameManager = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -11) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Equals("doughnut(Clone)")) {
            gameManager.GetComponent<GameManager>().AddScore(10);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            playerController.GetComponent<PlayerController>().doughnutActive = false;
        }
    }
}
