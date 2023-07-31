using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    private Slider slider;

    private void Awake() {
        slider = GetComponent<Slider>();
    }

    public void AddValue()
    {
        slider.value++;
    }

    public void ReduceValue()
    {
        slider.value--;
    }
}
