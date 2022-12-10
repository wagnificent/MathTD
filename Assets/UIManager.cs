using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TMP_InputField CurveInput;
    [SerializeField] TMP_InputField SlopeInput;
    [SerializeField] TMP_InputField OffsetInput;
    [SerializeField] Toggle NegativeXToggle;

    [SerializeField] Tower tower;

    public void ChangeCurve()
    {
        float value = float.Parse(CurveInput.text);
        tower.SetCurve(value);
    }

    public void ChangeSlope()
    {
        float value = float.Parse(SlopeInput.text);
        tower.SetSlope(value);
    }

    public void ChangeOffset()
    {
        float value = float.Parse(OffsetInput.text);
        tower.SetOffset(value);
    }

    public void ToggleNegativeX()
    {
        Debug.Log(NegativeXToggle.isOn);
        tower.SetNegative(NegativeXToggle.isOn);
    }
}
