using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class jumpTweener : MonoBehaviour
{

    public Vector2 scaleAtJump;
    public float timeToScaleJump;
    public float timeToJumpBack;
    public Vector2 scaleWhileFalling;
    public float timeToScaleFall;
    Vector2 normalScale;


    private void Start()
    {
        normalScale = this.transform.localScale;
    }

    public void startJump()
    {
        normalScale.x = System.Math.Sign(transform.localScale.x) * normalScale.x;
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(transform.localScale + (Vector3)scaleAtJump, timeToScaleFall)).Append(transform.DOScale(normalScale + scaleAtJump, timeToJumpBack));
    }

    public void reachPeekOfJump()
    {
        transform.DOScale(transform.localScale+(Vector3)scaleWhileFalling, timeToScaleFall);
    }

    public void backToNormalScale()
    {
        transform.DOScale(normalScale, 0.2f);
    }
}
