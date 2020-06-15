using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text gameOverText;
    private Text scoreText;
    private int score = 0;

    private AudioSource audioSource;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        // TODO: THIS MIGHT BREAK ONCE YOU HAVE MULTIPLE CHILDREN OF TEXT TYPE
        scoreText = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AddScore(int addScore) {
        score += addScore;
        scoreText.text = "Score: " + score;
    }

    // Made for objects that are destroyed when audio needs to be played
    public void PlayAudio(AudioClip soundEffect) {
        audioSource.PlayOneShot(soundEffect, 0.5f);
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
