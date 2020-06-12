using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    public GameObject doughnut;

    [SerializeField] private int boost = 50;
    private bool boostActive;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        boostActive = Input.GetKey("space");

        if (Input.GetKeyDown("down")) {
            Instantiate(doughnut, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate() {
        if (boostActive) {
            playerRb.AddForce(new Vector2(0, boost));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Equals("obstacle(Clone)")) {
            Destroy(gameObject);
        }
    }
}
