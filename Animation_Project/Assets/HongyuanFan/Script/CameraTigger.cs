using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTigger : MonoBehaviour
{
    public Transform MyCameraTransform;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Camera.main.transform.position = MyCameraTransform.transform.position;
            Camera.main.transform.rotation = MyCameraTransform.transform.rotation;

        }
    }
}
