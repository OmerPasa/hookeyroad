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
    private float Length;
    private bool In_Motion = false;
    //ANİMATİON REFERANCES!
    const string LIGHTFLICKER = "Light_Flicker";
    const string JUMPTORIGHT_LONG = "jumptoRight_Long";
    const string JUMPTOLEFT_LONG = "jumptoLeft_Long";
    public Joystick joystick;
      void Start()
    {
      transform.position = new Vector3(0.5f,4.186f,3.114f);
      GetComponent<Rigidbody>().velocity = new Vector3(5,0,0);// crowbar and crowbarrot had to have rigidbody to work!!
      animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
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

      if (joystick.Horizontal >= .2f)
      {
        ChangeAnimationState(JUMPTORIGHT_LONG);
      } else if (joystick.Horizontal <= -.2f)
      {
        ChangeAnimationState(JUMPTOLEFT_LONG);
      } else
      {
        ChangeAnimationState(LIGHTFLICKER);
      }

        //xAxis = Input.GetAxisRaw("Horizontal"); //don'T need to get raw change it to once pushed button sort of thing
        // But it may require to be landed on certain place in certain positiion so it will require some 
      if (!In_Motion)
      {
          In_Motion = true;
          ChangeAnimationState(LIGHTFLICKER);// basicly idle

          if(Input.GetKeyDown(KeyCode.Z))
        {
          ChangeAnimationState(JUMPTORIGHT_LONG);
          Length = animator.GetCurrentAnimatorStateInfo(0).length;
          Invoke("Motion_Happened",Length);
        }
          if(Input.GetKeyDown(KeyCode.V))
        {
          ChangeAnimationState(JUMPTOLEFT_LONG);
          Length = animator.GetCurrentAnimatorStateInfo(0).length;
          Invoke("Motion_Happened",Length);
        }
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
