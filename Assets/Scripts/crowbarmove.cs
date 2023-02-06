using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class crowbarmove : MonoBehaviour
{
    private Animator animator;
    public InputManager inputM;
    private Rigidbody2D rb2d;
    public string currentState;
    private float xAxis;
    private float yAxis;
    private string currentAnimaton;
    private float Length;
    private bool In_Motion = false;
    private bool LeftMotion;
    private bool RightMotion;

    // animation needed varibles.
    public float posZ;
    public float rotY;
    private float epsilon = 0.001f;
    public bool LeftBar;
    public bool MidBar;
    public bool RightBar;

    //ANİMATİON REFERANCES!
    const string Move_A = "Move_A";
    const string Move_Areverse = "Move_Areverse";
    const string Move_AS = "Move_AS";
    const string Move_ASreverse = "Move_ASreverse";
    const string Move_AW = "Move_AW";
    const string Move_AWreverse = "Move_AWreverse";
    const string Move_D = "Move_D";
    const string Move_Dreverse = "Move_Dreverse";
    const string Move_DS = "Move_DS";
    const string Move_DSreverse = "Move_DSreverse";
    const string Move_DW = "Move_DW";
    const string Move_DWreverse = "Move_DWreverse";
    const string LIGHTFLICKER = "Light_Flicker";
    const string JUMPTORIGHT_LONG = "jumptoRight_Long";
    const string JUMPTOLEFT_LONG = "jumptoLeft_Long";
    public VariableJoystick joystick;

    private void Awake() => inputM = new InputManager();

    //Route and Un-route events
    private void OnEnable() => inputM.Enable();
    private void OnDisable() => inputM.Disable();

    void Start()
    {
        //joystick = GetComponent<Joystick>();
        transform.position = new Vector3(0f, 4.003f, 1.6f);
        MidBar = true;
        GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 0);// crowbar and crowbarrot had to have rigidbody to work!!
        animator = GetComponent<Animator>();
        In_Motion = false;
    }

    void FixedUpdate()
    {
        //DeleteBehindPlayer();
        UnityEngine.Debug.Log(In_Motion);

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
    }

    void Update()
    {

        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        UnityEngine.Debug.Log(position.z + " current posz update2");
        UnityEngine.Debug.Log((int)rotation.eulerAngles.y + " current roty update2");

        float yRotation = (int)rotation.eulerAngles.y;
        if (yRotation > 180f)
        {
            yRotation -= 360f;
        }

        if (inputM.Player.A.triggered && Mathf.Abs(position.z - 1.6f) < epsilon && Mathf.Abs(yRotation - 180f) < epsilon && MidBar == true)
        {
            UnityEngine.Debug.Log("A triggered!!");
        }
        if (inputM.Player.D.triggered && Mathf.Abs(position.z - 1.6f) < epsilon && Mathf.Abs(yRotation - 0f) < epsilon && MidBar == true)
        {
            UnityEngine.Debug.Log("D triggered!!");
        }


        if (inputM.Player.A.triggered)
        {
            if (Mathf.Abs(position.z - 1.6f) < epsilon && Mathf.Abs(yRotation - 180f) < epsilon && MidBar == true)
            {
                MidBar = false;
                LeftBar = true;
                //UnityEngine.Debug.Log("A triggered!!");
                ChangeAnimationState(Move_A);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
            else if (Mathf.Abs(position.z - 3f) < epsilon && Mathf.Abs(yRotation - 0f) < epsilon && LeftBar == true)
            {
                MidBar = true;
                LeftBar = false;
                ChangeAnimationState(Move_Areverse);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
        }
        else if (inputM.Player.AS.triggered)
        {
            if (Mathf.Abs(position.z - 1.6f) < epsilon && Mathf.Abs(yRotation - 0f) < epsilon && MidBar == true)
            {
                MidBar = false;
                LeftBar = true;
                ChangeAnimationState(Move_AS);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
            else if (Mathf.Abs(position.z - 3f) < epsilon && Mathf.Abs(yRotation - 180f) < epsilon && LeftBar == true)
            {
                MidBar = true;
                LeftBar = false;
                ChangeAnimationState(Move_ASreverse);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
        }
        else if (inputM.Player.AW.triggered)
        {
            if (Mathf.Abs(position.z - 1.6f) < epsilon && Mathf.Abs(yRotation - 0f) < epsilon && MidBar == true)
            {
                MidBar = false;
                LeftBar = true;
                ChangeAnimationState(Move_AW);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
            else if (Mathf.Abs(position.z - 3f) < epsilon && Mathf.Abs(yRotation - 0f) < epsilon && LeftBar == true)
            {
                MidBar = true;
                LeftBar = false;
                ChangeAnimationState(Move_AWreverse);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
        }
        else if (inputM.Player.D.triggered)
        {
            if (Mathf.Abs(position.z - 1.6f) < epsilon && Mathf.Abs(yRotation - 0f) < epsilon && MidBar == true)
            {
                MidBar = false;
                RightBar = true;
                ChangeAnimationState(Move_D);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
            else if (Mathf.Abs(position.z - 0.1f) < epsilon && Mathf.Abs(yRotation - 180f) < epsilon && RightBar == true)
            {
                MidBar = true;
                RightBar = false;
                ChangeAnimationState(Move_Dreverse);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
        }
        else if (inputM.Player.DS.triggered)
        {
            if (Mathf.Abs(position.z - 1.6f) < epsilon && Mathf.Abs(yRotation - 0f) < epsilon && MidBar == true)
            {
                MidBar = false;
                RightBar = true;
                ChangeAnimationState(Move_DS);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
            else if (Mathf.Abs(position.z - 0.1f) < epsilon && Mathf.Abs(yRotation - 0f) < epsilon && RightBar == true)
            {
                MidBar = true;
                RightBar = false;
                ChangeAnimationState(Move_DSreverse);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
        }
        else if (inputM.Player.DW.triggered)
        {
            if (Mathf.Abs(position.z - 1.6f) < epsilon && Mathf.Abs(yRotation - 180f) < epsilon && MidBar == true)
            {
                MidBar = false;
                RightBar = true;
                ChangeAnimationState(Move_DW);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
            else if (Mathf.Abs(position.z - 0.1f) < epsilon && Mathf.Abs(yRotation - 180f) < epsilon && RightBar == true)
            {
                RightBar = false;
                MidBar = true;
                ChangeAnimationState(Move_DWreverse);
                Length = animator.GetCurrentAnimatorStateInfo(0).length;
                Invoke("Motion_Happened", Length);
            }
        }
        else
        {
            ChangeAnimationState(LIGHTFLICKER);
            Invoke("Motion_Happened", 0f);
        }

        if (inputM.Player.RotationW.triggered)
        {
            transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y + 180,
            transform.eulerAngles.z
    );
        }
        if (inputM.Player.RotationS.triggered)
        {
            transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y - 180,
            transform.eulerAngles.z
    );
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
        /*         if (!In_Motion)
                {
                    In_Motion = true;
                    if (RightMotion)
                    {
                        RightMotion = false;
                        ChangeAnimationState(JUMPTORIGHT_LONG);
                        UnityEngine.Debug.Log("RIGHT_LONG");
                        Length = animator.GetCurrentAnimatorStateInfo(0).length;
                        Invoke("Motion_Happened", Length);
                    }
                    if (LeftMotion)
                    {
                        LeftMotion = false;
                        ChangeAnimationState(JUMPTOLEFT_LONG);
                        UnityEngine.Debug.Log("LEFT_LONG");
                        Length = animator.GetCurrentAnimatorStateInfo(0).length;
                        Invoke("Motion_Happened", Length);
                    }
                    else
                    {
                        ChangeAnimationState(LIGHTFLICKER);
                        Invoke("Motion_Happened", 0f);
                    }
                } */
    }

    void Motion_Happened()
    {
        In_Motion = false;
        UnityEngine.Debug.Log("MOTİON HAPPENDED");
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
