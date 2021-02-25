using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator anim;
    
    //DON'T  FORGET TO PUT ANIMATION STRINGS !!!!
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        public string currentState;
        
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
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

