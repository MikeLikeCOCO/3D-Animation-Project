using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{  public GameObject player; // Reference to the game object with "Player" tag
    public float distance = 5f; // Distance from the player
    public float height = 2f; // Height of the camera above the player
    public float rotationSpeed = 2f; // Mouse sensitivity for camera rotation

    private float _currentRotationX = 0f;

    void Start()
    {
        // If player is not assigned, try to find an object with "Player" tag
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // If "Player" object is not found, log an error message
        if (player == null)
        {
            Debug.LogError("Player object not found! Make sure to assign the correct tag or reference the correct game object.");
        }

        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    void LateUpdate()
    {
        // Calculate the desired rotation based on mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        _currentRotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
        _currentRotationX = Mathf.Clamp(_currentRotationX, -90f, 90f); // Clamp the vertical rotation to avoid flipping

        // Set the rotation of the camera
        Quaternion rotation = Quaternion.Euler(_currentRotationX, transform.rotation.eulerAngles.y + mouseX, 0f);
        transform.rotation = rotation;

        // Set the position of the camera behind the player
        Vector3 targetPosition = player.transform.position - (rotation * Vector3.forward * distance);
        targetPosition.y = player.transform.position.y + height;
        transform.position = targetPosition;
    }
}
