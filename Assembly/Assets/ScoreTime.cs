using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour {

    float RunningTime;

	// Use this for initialization
	void Start () {
        RunningTime = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
        RunningTime += Time.deltaTime;
        this.GetComponent<Text>().text = "Time " + RunningTime.ToString();
    }
}
