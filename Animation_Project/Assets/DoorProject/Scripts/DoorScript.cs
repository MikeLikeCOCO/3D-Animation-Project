using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    private Animator _animator;

    public GameObject OpenPanel = null;

    private bool _isInsideTrigger = false;
    private int qTrigger = 0; // count OnTriggerEnter
   
	// Use this for initialization
	void Start () {
        _animator = transform.Find("Door").GetComponent<Animator>();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          //  qTrigger++;
            _isInsideTrigger = true;
            if(_animator.GetBool("open") == false) {
                OpenPanel.SetActive(true);
            }
            
        }
    }

    // void OnTriggerExit(Collider other)
    // {
        
    //     if (other.tag == "Player")
    //     {
            
    //         _isInsideTrigger = false;
            
    //         _animator.SetBool("open", false);
    //         OpenPanel.SetActive(false);
    //     }
    // }


     void OnTriggerExit(Collider other)
    {
       // Debug.Log(qTrigger);
       _isInsideTrigger = false;
       OpenPanel.SetActive(false);
        StartCoroutine(closeDoor(other));
    }
    IEnumerator closeDoor(Collider other)
    {
        float timeToWait = 4f;
        yield return new WaitForSeconds(timeToWait);
        if (other.tag == "Player")
        {
          //  qTrigger--;
           // if(qTrigger == 0) {
            
            
            _animator.SetBool("open", false);
            
          //  }

        }
    }

    private bool IsOpenPanelActive
    {
        get
        {
            return OpenPanel.activeInHierarchy;
        }
    }

    // Update is called once per frame
    void Update () {

        if(IsOpenPanelActive && _isInsideTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                OpenPanel.SetActive(false);
                _animator.SetBool("open", true);  
            }
        }
	}
}
