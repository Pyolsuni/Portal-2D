using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool Down = false;
        bool Down_right = false;
        bool Down_left = false;
        bool Up = false;
        bool Up_right = false;
        bool Up_left = false;
        bool Right = false;
        bool Left = false;


        if (horizontal > float.Epsilon && vertical == 0)
        {
            Right = true;
            
        }
        else if (vertical > float.Epsilon && horizontal == 0)
        {
            Up = true;
            
        }
        else if (-horizontal > float.Epsilon && vertical == 0)
        {
            Left = true;
            
        }
        else if (-vertical > float.Epsilon && horizontal == 0)
        {
            Down = true;
            
        }

        else if (horizontal > float.Epsilon && vertical > float.Epsilon)
        {
            Up_right = true;
            
        }

        else if (-horizontal > float.Epsilon && vertical > float.Epsilon)
        {
            Up_left = true;
            
        }

        else if (horizontal > float.Epsilon && -vertical > float.Epsilon)
        {
            Down_right = true;
            
        }

        else if (-horizontal > float.Epsilon && -vertical > float.Epsilon)
        {
            Down_left = true;
            
        }

        animator.SetBool("Right", Right);
        animator.SetBool("Up", Up);
        animator.SetBool("Left", Left);
        animator.SetBool("Down", Down);
        animator.SetBool("Up_right", Up_right);
        animator.SetBool("Up_left", Up_left);
        animator.SetBool("Down_right", Down_right);
        animator.SetBool("Down_left", Down_left);

    }
}
