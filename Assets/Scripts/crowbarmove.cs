using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class crowbarmove : MonoBehaviour
{
    private Animator animator;
    private InputManager inputM;
    private Rigidbody2D rb2d;
    public string currentState;
    private float xAxis;
    private float yAxis;
    private string currentAnimaton;
    private float Length;
    private bool In_Motion = false;
    private bool LeftMotion;
    private bool RightMotion;
    //ANİMATİON REFERANCES!
    const string LIGHTFLICKER = "Light_Flicker";
    const string JUMPTORIGHT_LONG = "jumptoRight_Long";
    const string JUMPTOLEFT_LONG = "jumptoLeft_Long";
    public VariableJoystick joystick;
    void Start()
    {
        //joystick = GetComponent<Joystick>();
        transform.position = new Vector3(0f, 4.003f, 3.159f);
        GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);// crowbar and crowbarrot had to have rigidbody to work!!
        animator = GetComponent<Animator>();
        In_Motion = false;
    }

    void FixedUpdate()
    {
        Debug.Log(In_Motion);

        // doesn't compatible with animator :( 
        //this if makes sure , crowbar in Z position
        if (transform.position.z <= 0.08 || transform.position.z >= 4.60)
        {
            // Create values between this range (minY to maxY) and store in yPos
            float zPos = Mathf.Clamp(transform.position.z, 0.113f, 3.161f);

            // Assigns these values to the Transform.position component of the Player
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.5f, 0.5f), transform.position.y, transform.position.z);

        if (inputM.Player.A.triggered)
        {
            Vector3 position = transform.position;
            position.z += 1.5f;
            transform.position = position;
        }
        if (inputM.Player.D.triggered)
        {
            Vector3 position = transform.position;
            position.z -= 1.5f;
            transform.position = position;
        }
        if (inputM.Player.RotationW.triggered)
        {
            RightMotion = true;
        }
        if (inputM.Player.RotationS.triggered)
        {
            LeftMotion = true;
        }
        /*if (joystick.Horizontal >= .2f)
        {
          ChangeAnimationState(JUMPTORIGHT_LONG);
          Debug.Log("RIGHT_LONG");;
        } else if (joystick.Horizontal <= -.2f)
        {
          ChangeAnimationState(JUMPTOLEFT_LONG);
          Debug.Log("LEFT_LONG");
        } else
        {
          ChangeAnimationState(LIGHTFLICKER);
        }*/

        //xAxis = Input.GetAxisRaw("Horizontal"); //don'T need to get raw change it to once pushed button sort of thing
        // But it may require to be landed on certain place in certain positiion so it will require some 
        if (!In_Motion)
        {
            In_Motion = true;
            if (RightMotion)
            {
                RightMotion = false;
                ChangeAnimationState(JUMPTORIGHT_LONG);
                Debug.Log("RIGHT_LONG");
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
            if (LeftMotion)
            {
                LeftMotion = false;
                ChangeAnimationState(JUMPTOLEFT_LONG);
                Debug.Log("LEFT_LONG");
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
            else
            {
                ChangeAnimationState(LIGHTFLICKER);
                Invoke("Motion_Happened", 0f);
            }
        }
    }
    void Motion_Happened()
    {
        In_Motion = false;
        Debug.Log("MOTİON HAPPENDED");
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
