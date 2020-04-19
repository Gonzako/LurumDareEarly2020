using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;

public class CollectablesUpdater : MonoBehaviour
{
    [SerializeField] private IntReference _collectablesAmount = default(IntReference);
    [SerializeField] private Text _targetUI;

    private void Update()
    {
        _targetUI.text = _collectablesAmount.Value.ToString();
    }
}
