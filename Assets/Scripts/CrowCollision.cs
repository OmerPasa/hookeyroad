using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrowCollision : MonoBehaviour
{

    public Animator animator;
    private Vector3 finalPosition;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Transform childObject = transform.GetChild(0);

        if (!animator.GetCurrentAnimatorStateInfo(0).loop)
        {
            finalPosition = childObject.position;
        }

        childObject.position = finalPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("has collide");
    }
}
