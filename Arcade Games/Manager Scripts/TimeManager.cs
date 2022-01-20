using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.ProBuilder;

public class TimeManager : MonoBehaviour
{
    public Slider slowMoSlider;
    public Text slowMoText;

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    float slowMoFloat = 1;
    float sliderValue;

    private void Update()
    {
        sliderValue = slowMoSlider.value;

        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        if (Input.GetKey(KeyCode.LeftShift) && sliderValue > 0.0f)
        {
            SlowMotion();
            DisplaySlowMotion();
        }

        slowMoText.text = Mathf.Round(slowMoSlider.value * 100) + " %";
    }

    public void SlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void DisplaySlowMotion()
    {
        slowMoSlider.value = slowMoFloat;

        slowMoFloat -= .1f * Time.unscaledDeltaTime;
    }
}
