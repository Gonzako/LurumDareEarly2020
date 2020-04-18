using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[RequireComponent(typeof(IPlayerVelocity), typeof(ICheckGround))]
public class playerJump : MonoBehaviour
{
    public FloatGameEvent jumpEvent;
    public FloatGameEvent peakEvent;        
    public JumpParabola upParav = new JumpParabola(2.5f, 3, 1);
    public JumpParabola fallParav = new JumpParabola(3, 1.5f, 1);

    ICheckGround gCheck;
    IPlayerVelocity pVel;
    JumpParabola currentParav;
    bool wantJump = false;
    Rigidbody2D rb;
    Vector2 previousVel;
    // Start is called before the first frame update
    void Start()
    {
        pVel = GetComponent<IPlayerVelocity>();
        gCheck = GetComponent<ICheckGround>();
        rb = GetComponent<Rigidbody2D>();
        currentParav = fallParav;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && gCheck.areWeGrounded)
        {
            queueJump();
        }
    }

    void FixedUpdate()
    {
        Debug.Log(rb.velocity);
        if (wantJump)
        {
            currentParav = upParav;
            jumpEvent?.Raise(upParav.getTimeToPeak(pVel.maxVelocity));
            if(rb.velocity.y < 0)
            {
                rb.velocity += Vector2.down * rb.velocity.y;
            }

            rb.velocity += currentParav.getStartingVelocity(pVel.maxVelocity) * Vector2.up;
        }
        if(rb.velocity.y < 0 && previousVel.y >= 0)
        {
            handlePeak();
        }
        if (rb.velocity.y != 0) rb.gravityScale = currentParav.getGravScale(pVel.maxVelocity);
        else rb.gravityScale = 1;
        wantJump = false;
        previousVel = rb.velocity;
    }

    private void handlePeak()
    {
        currentParav = fallParav;
        rb.gravityScale = currentParav.getGravScale(pVel.maxVelocity);
    }

    public void queueJump()
    {
        wantJump = true;
    }
}

[System.Serializable]
public struct JumpParabola
{
    public float jumpHeight;
    public float peakDistance;
    [Range(0.1f, 5)]
    public float velocityScale;

    public JumpParabola(float h = 2.5f, float pdist = 2, float velocityScale = 1)
    {
        jumpHeight = h;
        peakDistance = pdist;
        this.velocityScale = velocityScale;
    }

    public float getTimeToPeak(float sideVel)
    {
        return peakDistance / sideVel * velocityScale;
    }

    public float getStartingVelocity(float sideVel)
    {
        var vel = sideVel * velocityScale / peakDistance;
        vel *= 2 * jumpHeight;
        return vel;
    }

    //This will be used to alter grav scale of a rigidbody;
    public float getGravScale(float sideVel)
    {
        var grav = sideVel * velocityScale * sideVel * velocityScale;
        grav *= - 2 * jumpHeight;
        grav /= peakDistance * peakDistance;
        return grav / Physics2D.gravity.y;
    }
}