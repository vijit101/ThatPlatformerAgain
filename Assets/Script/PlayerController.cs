using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public AnimationClip Jump;
    public float moveSpeed, jumpForce;
    float horizontalValue,verticalValue;
    Rigidbody2D rgbd;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        GetHorizontalInput();
        GetVerticalInput();
        MovePlayer(horizontalValue,verticalValue);
        InputForJump();
        SetAnimatorSpeedValue();        
    }

    public void GetHorizontalInput()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");        
    }
    
    public void GetVerticalInput()
    {
        verticalValue = Input.GetAxisRaw("Jump");        
    }

    private void SetAnimatorSpeedValue()
    {
        CheckFlipped();
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalValue));
    }

    private void CheckFlipped()
    {
        Vector3 scale = transform.localScale;
        if (horizontalValue < 0)
        {
            scale.x = -1 *Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    private void MovePlayer(float horizontal,float vertical)
    {
        Vector2 pos = transform.position;
        pos.x = pos.x + horizontal * moveSpeed*Time.deltaTime;
        transform.position = pos;
        if (vertical > 0)
        {
            rgbd.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);        
        }
    }

    private void InputForJump()
    {
        if (verticalValue>0)
        {
            playerAnimator.SetBool("isJump", true);
        }
        else
        {
            playerAnimator.SetBool("isJump", false);
        }
    }

}
