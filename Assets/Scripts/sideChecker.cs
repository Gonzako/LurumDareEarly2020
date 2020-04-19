using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideChecker : MonoBehaviour
{
    simpleSidewaysMovement mov;
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        mov = GetComponentInParent<simpleSidewaysMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!facingRight && mov.currentDirection > 0)
        {
            flip();
        }
        else if(facingRight && mov.currentDirection < 0)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
