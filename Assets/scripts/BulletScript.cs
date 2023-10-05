using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Bullet collided with Enemy.");

            // Destroy the bullet GameObject
            Destroy(gameObject);

            // Destroy the enemy GameObject
            Destroy(other.gameObject);
        }
    }
}