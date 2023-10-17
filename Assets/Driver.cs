using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.05f;
    [SerializeField] float moveSpeed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speed = Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveSpeed * speed, 0);
    }
}
