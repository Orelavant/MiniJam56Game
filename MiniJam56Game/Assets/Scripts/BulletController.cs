﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int speed = 6;

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -11) {
            Destroy(gameObject);
        }
    }
}
