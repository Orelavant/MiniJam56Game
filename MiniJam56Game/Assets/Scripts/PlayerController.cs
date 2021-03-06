﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool freezeRotate;
    
    Rigidbody2D playerRb;
    public GameObject doughnut;

    public GameObject boostStorage;

    [SerializeField] private int boost = 50;
    private bool boostActive;

    public bool doughnutActive = false;

    public AudioClip boostSound;
    public AudioClip doughnutDropSound;
    public AudioClip deathSound;
    private AudioSource audioSource;

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("EventSystem");
        playerRb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        boostActive = Input.GetKey("space");

        if (Input.GetKeyDown("down") && !doughnutActive) {
            Instantiate(doughnut, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(doughnutDropSound, 0.5f);
            doughnutActive = true;
        }

        // Rotation code (modified): https://answers.unity.com/questions/630670/rotate-2d-sprite-towards-moving-direction.html
        if (!freezeRotate) {
            Quaternion start = transform.rotation;
            Vector2 moveDirection = playerRb.velocity;
            if (moveDirection != Vector2.zero) {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Lerp(start, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime);
            }
        }

        if (boostActive) {
            boostStorage.SetActive(true);
        } else {
            boostStorage.SetActive(false);
        }
    }

    private void FixedUpdate() {
        if (boostActive) {
            playerRb.AddForce(new Vector2(0, boost));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.Equals("obstacle(Clone)") || collision.name.Equals("bullet(Clone)")) {
            gameManager.GetComponent<GameManager>().PlayAudio(deathSound);
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.name == "bounds1") {
            freezeRotate = true;
        }
        if (collision.collider.name == "bounds2") {
            freezeRotate = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.name == "bounds1") {
            freezeRotate = false;
        }
        if (collision.collider.name == "bounds2") {
            freezeRotate = false;
        }
    }
}
