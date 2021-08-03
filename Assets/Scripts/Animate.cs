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
    //DON'T  FORGET TO PUT ANIMATION  !!!!
    /*
    rightslideUp;
    rightslideDown;
    leftslideUp;
    leftslideDown;
    */
    // Update is called once per frame
    void Start() 
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal"); //don'T need to get raw change it to once pushed button sort of thing
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
    
