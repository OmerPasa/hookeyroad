using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    public string currentState;
    private float xAxis;
    private float yAxis;
    //ANİMATİON REFERANCES!
    const string LIGHTFLICKER = "Light_Flicker";
    const string JUMPTORIGHT_LONG = "jumptoRight_Long";
    const string JUMPTOLEFT_LONG = "jumptoLeft_Long";
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //xAxis = Input.GetAxisRaw("Horizontal"); //don'T need to get raw change it to once pushed button sort of thing
        // But it may require to be landed on certain place in certain positiion so it will require some 
        if(Input.GetKeyDown(KeyCode.Z))
        {
            anim.Play(JUMPTORIGHT_LONG);
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            anim.Play(JUMPTOLEFT_LONG);
        }
    }

    void  ChangeAnimationState(string newState)
    {
        //stoping animation to repeat or interrup itself.
        if (currentState == newState) return;

        //just saying unity to play.
        anim.Play(newState);

        //reassingning current state
        currentState = newState;
    }
}
    
