using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootUp : MonoBehaviour {

    public int speedUp = 0;
    public int speedLeft = 0;
    private Rigidbody2D obstacleRb;

    // Start is called before the first frame update
    void Start()
    {
        obstacleRb = GetComponent<Rigidbody2D>();
        obstacleRb.velocity = Vector2.up * speedUp;
    }

    // Update is called once per frame
    void Update()
    {
        // Adds force to bomb to travel left, improve if possible
        obstacleRb.AddForce(Vector2.left * speedLeft);

        // Rotation code: https://answers.unity.com/questions/630670/rotate-2d-sprite-towards-moving-direction.html
        Vector2 moveDirection = obstacleRb.velocity;
        if (moveDirection != Vector2.zero) {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
