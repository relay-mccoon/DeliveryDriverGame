using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    // Fields
    // float speedCoefficient = 1f;
    /// <summary>
    /// Speed Coefficient. Must be between 0 and 1.
    /// </summary>
    [SerializeField] float speedCoefficient = 0.1f;
    [SerializeField] Vector3 startPosition = new Vector3(0f, 0f, 0f);
    [SerializeField] Vector3 finalPosition = new Vector3(10f, 10f, 0f);
    // Vector2 direction;
    // Rigidbody2D pedRigidbody;
    Vector3 moveVector;
    float speedNormalization = 0.1f;

    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        calcMoveVector();
    }

    // Update is called once per frame
    void Update()
    {
        // moving with physics
        // direction = (finalPosition - transform.position).normalized;
        // float distance = Vector3.Distance(finalPosition,  transform.position);
        // float speed = Mathf.Clamp(distance*speedCoefficient, 0f, maxSpeed);
        // pedRigidbody = GetComponent<Rigidbody2D>();
        // pedRigidbody.velocity = direction * speed;

        // moving with set speeds
        transform.Translate(moveVector);

        if(transform.position == finalPosition){
            Debug.Log("reached final position");
            updatePath();
        }
    }

    private void updatePath() {
        Vector3 tempVec = finalPosition;
        finalPosition = startPosition;
        startPosition = tempVec;
        calcMoveVector();
    }

    private void calcMoveVector() {
        Debug.Log("calculating move vector");
        moveVector = Vector3.Lerp(startPosition, finalPosition, speedCoefficient * speedNormalization);
    }
}
