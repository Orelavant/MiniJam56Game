using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutController : MonoBehaviour {

    private float yBounds = 5.2f;
    private float xBounds = 8.5f;
    
    private int speed = 3;
    Vector2 movement;

    private GameObject playerController;

    // Start is called before the first frame update
    void Start() {
        playerController = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update() {
        // Travel downwards (local to doughnut)
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy when out of bounds
        if (transform.position.y < -yBounds || transform.position.y > yBounds) {
            Destroy(gameObject);
            playerController.GetComponent<PlayerController>().doughnutActive = false;
        }
        if (transform.position.x < -xBounds || transform.position.x > xBounds) {
            Destroy(gameObject);
            playerController.GetComponent<PlayerController>().doughnutActive = false;
        }


        // Input
        movement.x = Input.GetAxisRaw("Horizontal");

        
    }

    private void FixedUpdate() {
        transform.Translate(movement * speed * Time.fixedDeltaTime);

        // Rotate
        transform.Rotate(0, 0, movement.x);
    }
}
