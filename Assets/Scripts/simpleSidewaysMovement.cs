using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[RequireComponent(typeof(Rigidbody2D))]
public class simpleSidewaysMovement : MonoBehaviour, IPlayerVelocity
{
    public float currentDirection => side;
    public float maxVelocity => horizontalVelocity;
    public BoolVariable walking;       
    [SerializeField]
    private float horizontalVelocity = 2;
    //public float dragWhenSlowingDown = 10;

    private Rigidbody2D rb;
    private float side;


    //private float oldDrag;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //oldDrag = rb.drag;
    }

    private void Update()
    {
        side = Input.GetAxis("Horizontal");
        walking.Value = side != 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(side*horizontalVelocity, rb.velocity.y);
        //Debug.Log(rb.velocity);
    }
}
