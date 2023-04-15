using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_chage : MonoBehaviour
{
    public GameObject playerCameraPrefab; // Prefab of the player camera
    public GameObject otherCameraPrefab; // Prefab of the other camera

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Get the current camera
            Camera currentCamera = GetComponent<Camera>();

            // Delete the current camera
            Destroy(currentCamera.gameObject);

            // Instantiate the other camera prefab
            GameObject newCamera = Instantiate(otherCameraPrefab, transform.position, transform.rotation);

            // Set the new camera as the player camera
            playerCameraPrefab.GetComponent<Camera>().enabled = true;
        }
    }

   
}
