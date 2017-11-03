using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnappingScriptGameController : MonoBehaviour
{
    public Text DisplayTimeExpended;
    public Text DisplayLooseParts;
    public Text DisplayUnanswered;

    float RunningTime;

    // Use this for initialization
    void Start()
    {
        RunningTime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        RunningTime += Time.deltaTime;
        DisplayTimeExpended.text = "Time " + RunningTime.ToString();
    }
}
