using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowbarmove : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    public string currentState;
    private float xAxis;
    private float yAxis;
    private string currentAnimaton;
    private bool In_Motion;
    //ANİMATİON REFERANCES!
    const string LIGHTFLICKER = "Light_Flicker";
    const string JUMPTORIGHT_LONG = "jumptoRight_Long";
    const string JUMPTOLEFT_LONG = "jumptoLeft_Long";
      void Start()
    {
      transform.position = new Vector3(0.5f,4.186f,3.114f);
      GetComponent<Rigidbody>().velocity = new Vector3(5,0,0);// crowbar and crowbarrot had to have rigidbody to work!!
    }
    
    void Update()
    {
      
      // doesn't compatible with animator :( 
      //this if makes sure , crowbar in Z position
      if (transform.position.z <= 0.08 || transform.position.z >=4.60)
      {
      // Create values between this range (minY to maxY) and store in yPos
      float zPos = Mathf.Clamp(transform.position.z, 0.113f,3.161f);    

      // Assigns these values to the Transform.position component of the Player
      transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
      }
    //transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.5f, 0.5f), transform.position.y, transform.position.z);
      
      if (Input.GetKeyDown(KeyCode.A))
      {
        Vector3 position = transform.position;
        position.z += 1.5f;
        transform.position = position;
      }
      if (Input.GetKeyDown(KeyCode.D))
      {
        Vector3 position = transform.position;
        position.z -= 1.5f;
        transform.position = position;
      }

        //xAxis = Input.GetAxisRaw("Horizontal"); //don'T need to get raw change it to once pushed button sort of thing
        // But it may require to be landed on certain place in certain positiion so it will require some 
      if (!In_Motion)
      {
          In_Motion = true;
          ChangeAnimationState("LIGHTFLICKER");
        
        
          if(Input.GetKeyDown(KeyCode.Z))
        {
          //ChangeAnimationState("JUMPTORIGHT_LONG");
          animator.Play(JUMPTORIGHT_LONG);
        }
          if(Input.GetKeyDown(KeyCode.V))
        {
          ChangeAnimationState("JUMPTOLEFT_LONG");
          //anim.Play(JUMPTOLEFT_LONG);
        }
        Invoke("Motion_Happened",0f);
      }
    }
    void Motion_Happened()
    {
      In_Motion = false;
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
