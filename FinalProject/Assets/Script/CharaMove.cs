using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{   
   public float translationSpeed = 2.0f;
   public float rotationSpeed = 100.0f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       float translation = Input.GetAxis("Vertical") * translationSpeed;
       translation*=Time.deltaTime;
       transform.Translate(0,0,translation);

       float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
       rotation*=Time.deltaTime;
       transform.Rotate(0,rotation,0);

       if (translation !=0)
       {
          anim.SetBool("isWalking", true);
          if(translation <0)
          anim.SetFloat("charSpeed",-1.0f);
          else
          anim.SetFloat("charSpeed",1.0f);
       }
       else
       {
          anim.SetBool("isWalking", false);
       }      
    }
}
