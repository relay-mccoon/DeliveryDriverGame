using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class Driver : MonoBehaviour
{
    bool spedUp = false;
    [SerializeField] float steerSpeed = 0.05f;
    [SerializeField] float defaultSpeed = 0.03f;
    [SerializeField] float boostSpeed = 15f;
    [SerializeField] float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speed = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speed, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Speed Up" && !spedUp) {
            moveSpeed = boostSpeed;
            spedUp = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (spedUp) {
            spedUp = false;
            moveSpeed = defaultSpeed;
        }
    }
}
