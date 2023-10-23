using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // This thing's position (camera) should be the same as the car's position
    [SerializeField] GameObject thingToFollow;
    void LateUpdate()
    {
        // we need to set the position to be the car's position
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
