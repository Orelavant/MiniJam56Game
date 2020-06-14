using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: THIS MIGHT BREAK ONCE YOU HAVE MULTIPLE CHILDREN OF TEXT TYPE
        scoreText = GameObject.Find("Canvas").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int addScore) {
        score += addScore;
        scoreText.text = "Score: " + score;
    }
}
