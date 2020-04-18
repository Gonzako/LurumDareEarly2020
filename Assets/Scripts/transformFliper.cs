using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformFliper : MonoBehaviour
{

    public void flipScale()
    {
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
