using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // Define range for obstacles
    private float maxY = 1;
    private float minY = 0.5f;
    private float maxX = -0.5f;
    private float minX = -1;

    private int maxSpeed = 12;
    private int minSpeed = 8;

    private Rigidbody2D obstacleRb;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRb = GetComponent<Rigidbody2D>();

        obstacleRb.velocity = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)) * Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation code: https://answers.unity.com/questions/630670/rotate-2d-sprite-towards-moving-direction.html
        Vector2 moveDirection = obstacleRb.velocity;
        if (moveDirection != Vector2.zero) {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (transform.position.y < -5) {
            Destroy(gameObject);
        }
    }
}
