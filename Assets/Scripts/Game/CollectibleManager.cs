using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class CollectibleManager : MonoBehaviour
{


    [SerializeField] private Collectable _info;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private GameObjectGameEvent _onCollectedEvent = default(GameObjectGameEvent);
    [SerializeField] private IntReference _collectablesAmount = default(IntReference);
    
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player"){
           _onCollectedEvent.Raise();
           _collectablesAmount.Value += 1;
       }
    }

    private void Start()
    {
        _renderer.sprite = _info._collectableSprite;
    }

    private void OnDrawGizmosSelected()
    {
        _renderer.sprite = _info._collectableSprite;
    }
}
