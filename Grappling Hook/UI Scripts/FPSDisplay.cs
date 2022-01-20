using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public int avgFrameRate;
    Text displayText;

    private void Start()
    {
        displayText = GetComponent<Text>();
    }

    public void Update()
    {
        float current = (int)(1f / Time.unscaledDeltaTime);
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        displayText.text = "FPS: " + avgFrameRate.ToString();
    }
}