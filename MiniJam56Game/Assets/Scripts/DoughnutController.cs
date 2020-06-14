using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutController : MonoBehaviour {
    
    private int speed = 3;
    Vector2 movement;

    private GameObject playerController;

    // Start is called before the first frame update
    void Start() {
        playerController = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5.2) {
            Destroy(gameObject);
            playerController.GetComponent<PlayerController>().doughnutActive = false;
        }

        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() {
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }
}
