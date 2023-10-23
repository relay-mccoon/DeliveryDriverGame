using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 collisionColor;
    [SerializeField] float packagePickupDelay = 0.3f;
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Uh oh! Collision!");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("You've found the package!");
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Destroy(other.gameObject, packagePickupDelay);
        }
        else if (other.tag == "Customer") {
            Debug.Log("Found the customer.");
            if (hasPackage) {
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
                Debug.Log("You've delivered the package to the customer!");
            }
            else {
                Debug.Log("You don't have the package. Go find it!");
            }
        }
        else {
            Debug.Log("this is something else entirely");
        }
    }
}
