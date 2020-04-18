using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class onTriggerKill : MonoBehaviour
{
    public LayerMask killersLayer;
    public UnityEvent killResponse;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (killersLayer == (killersLayer | (1 << collision.gameObject.layer)))
        {
            killResponse.Invoke();
            Destroy(this.gameObject); 
        }
    }

}
