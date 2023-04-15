using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosnter : MonoBehaviour
{public Transform player;     // Reference to the player's transform
    public float speed = 5.0f;   // Movement speed of the AI

    void Update()
    {
        // Calculate the direction from the AI to the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Ignore vertical movement

        // Move the AI towards the player
        transform.position += direction.normalized * speed * Time.deltaTime;

        // Rotate the AI to face the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.1f);
    }
}
