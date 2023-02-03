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
        transform.position = new Vector3(0f, 4.003f, 3.159f);
        LeftBar = true;
        GetComponent<Rigidbody>().velocity = new Vector3(4, 0, 0);// crowbar and crowbarrot had to have rigidbody to work!!
        animator = GetComponent<Animator>();
        In_Motion = false;
    }

    void FixedUpdate()
    {
        //DeleteBehindPlayer();
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
        posZ = transform.position.z;
        rotY = transform.eulerAngles.y;
    }

    void Update()
    {
        if (inputM.Player.A.triggered && posZ == 1.6 && rotY == -180  && MidBar = true)
        {
            MidBar = false;
            LeftBar= true;
            ChangeAnimationState(Move_A);
        }
        if (inputM.Player.AS.triggered && posZ == 1.6 && rotY == 0  && MidBar = true)
        {
            MidBar = false;
            LeftBar= true;
            ChangeAnimationState(Move_AS); 
        }
        if (inputM.Player.AW.triggered && posZ == 1.6 && rotY == 0  && MidBar = true)
        {
            MidBar = false;
            LeftBar= true;
            ChangeAnimationState(Move_AW);
        }
        if (inputM.Player.A.triggered && posZ == 3 && rotY == 0  && LeftBar = true)
        {
            MidBar = true;
            LeftBar= false;
            ChangeAnimationState(Move_Areverse);  
        }
        if (inputM.Player.AS.triggered && posZ == 3 && rotY == -180  && LeftBar = true )
        {
            MidBar = true;
            LeftBar= false;
            ChangeAnimationState(Move_ASreverse);
        }
        if (inputM.Player.AW.triggered && posZ == 3 && rotY == 0  && LeftBar = true)
        {
            MidBar = true;
            LeftBar= false;
            ChangeAnimationState(Move_AWreverse);  
        }


        if (inputM.Player.D.triggered && posZ == 1.6 && rotY == 0  && MidBar = true) 
        {
            MidBar = false;
            RightBar = true;
            ChangeAnimationState(Move_D);
        }
        if (inputM.Player.DS.triggered && posZ == 1.6 && rotY == 0  && MidBar = true)
        {
            MidBar = false;
            RightBar = true;
            ChangeAnimationState(Move_DS);  
        }
        if (inputM.Player.DW.triggered && posZ == 1.6 && rotY == -180  && MidBar = true)
        {
            MidBar = false;
            RightBar = true;
            ChangeAnimationState(Move_DW);
        }
        if (inputM.Player.D.triggered && posZ == 0.1 && rotY == -180  && RightBar = true)
        {
            MidBar = true;
            RightBar = false;
            ChangeAnimationState(Move_Dreverse);  
        }
        if (inputM.Player.DS.triggered && posZ == 0.1 && rotY == 0  && RightBar = true)
        {
            MidBar = true;
            RightBar = false;
            ChangeAnimationState(Move_DSreverse);
        }
        if (inputM.Player.DW.triggered && posZ == 0.1 && rotY == -180  && RightBar = true)
        {
            MidBar = true;
            RightBar = false;
            ChangeAnimationState(Move_DWreverse);  
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
