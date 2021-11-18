using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingAply : MonoBehaviour
{
    private Text _newIndicator;
    void Start() {
        _newIndicator = gameObject.GetComponent<Text>(); 
    }
    public void UpdateIndicator(Text Indicator) {
        Indicator.text = _newIndicator.text;
    }
}
