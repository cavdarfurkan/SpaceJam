using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValueXpBar(int maxVal)
    {
        slider.maxValue = maxVal;
    }

    public void SetValueXpBar(int currentVal)
    {
        slider.value = currentVal;
    }
}
