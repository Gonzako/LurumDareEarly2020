using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class goombaController : MonoBehaviour
{
    public Transform raycastPoint;
    public float speed = 4f;
    public float rayDistance = 1;
    public LayerMask whatIsGround;

    public UnityEvent flipResponse;

    private bool movingRight = true;
    private Rigidbody2D rb;
    private RaycastHit2D result;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        result = Physics2D.Raycast(raycastPoint.position, Vector2.down, rayDistance, whatIsGround);
        if (!result.collider || result.distance == 0)
        {
            Flip();
        }
        if(rb.velocity.x != speed)
        {
            var vel = rb.velocity;
            vel.x = movingRight ? speed : -speed;
            rb.velocity = vel;
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        var vel = rb.velocity;
        vel.x = Mathf.Sign(vel.x);
        vel.x *= -1;
        vel.x *= speed;
        rb.velocity = vel;
        flipResponse.Invoke();

    }

    private void OnDrawGizmosSelected()
    {
        if(result.collider != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(raycastPoint.position, raycastPoint.position + Vector3.down * result.distance);
        }
        else
        {
            Gizmos.DrawLine(raycastPoint.position, raycastPoint.position + Vector3.down * rayDistance);
        }
    }
}
