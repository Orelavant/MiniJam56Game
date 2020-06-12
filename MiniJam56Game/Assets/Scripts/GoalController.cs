using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private int speed = 3;

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -11) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collided with " + collision.name);
        if (collision.name.Equals("doughnut(Clone)")) {
            print("ye");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
