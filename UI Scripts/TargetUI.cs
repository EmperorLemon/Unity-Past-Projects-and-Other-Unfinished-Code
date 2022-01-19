using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TargetUI : MonoBehaviour
{
    public Text targetsHitText;
    public Text targetsMissedText;

    public GunScript script;

    private void Update()
    {
        DisplayTargets();
    }

    void DisplayTargets()
    {
        targetsHitText.text = "Targets Hit: " + script.targetsHit;
        targetsMissedText.text = "Shots Missed: " + script.targetsMissed;
    }
}
