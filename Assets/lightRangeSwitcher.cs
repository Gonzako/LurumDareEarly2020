using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using DG.Tweening;

public class lightRangeSwitcher : MonoBehaviour
{

    public float startWait = 2f;
    public GameEvent onTorchLightUp;
    public float startRange = 13;
    public Vector2 minMaxRange = new Vector2(5, 10);
    public Vector2 minMaxTime = new Vector2(0.2f, 3);
    private Light light;

    private void Start()
    {
        light = GetComponent<Light>();
        light.range = 0;
        StartCoroutine(tweenToNextTorchRange());
    }

    public IEnumerator tweenToNextTorchRange()
    {
        yield return new WaitForSeconds(startWait);
        onTorchLightUp?.Raise();
        Tween t = DOTween.To(() => light.range, x => light.range = x, startRange, 0.5f);
        t.Play();
        while (true)
        {
            yield return new WaitUntil(()=>!t.IsPlaying());
            t = DOTween.To(() => light.range, x => light.range = x,
                Random.Range(minMaxRange.x, minMaxRange.y), Random.Range(minMaxTime.x, minMaxTime.y));
            t.Play();
        }
    }
}
