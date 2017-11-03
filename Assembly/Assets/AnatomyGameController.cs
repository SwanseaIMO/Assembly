using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnatomyGameController : MonoBehaviour
{
    public Text DisplayTimeExpended;
    public Text DisplayScoreTime;
    public Text DisplayLooseParts;
    public Text DisplayUnanswered;
    public Text DisplayRunning;

    private string DisplayTimeExpendedEditorSet;
    private string DisplayScoreTimeEditorSet;
    private string DisplayLoosePartsEditorSet;
    private string DisplayUnansweredEditorSet;


    private float RunningTime = 0.0f;
    public float SavedTime = 0.0f;
    private float ScoreTime = 0.0f;
    private int Seconds, Minutes;

    private bool Running;

    public List<GameObject> LooseParts;
    public List<GameObject> Unanwsered;

    // Use this for initialization
    void Start()
    {
        DisplayRunning.text = "Started";
        Running = true;
        DisplayTimeExpendedEditorSet = DisplayTimeExpended.text;
        DisplayScoreTimeEditorSet = DisplayScoreTime.text;
        DisplayLoosePartsEditorSet = DisplayLooseParts.text;
        DisplayUnansweredEditorSet = DisplayUnanswered.text;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Running) UpdateBoard();
        CheckWinState();
    }

    void CheckWinState()
    {
        if (LooseParts.Count == 0 && Unanwsered.Count == 0)
        {
            DisplayRunning.text = "Finished";
            Running = false;
        }
    }

    void UpdateBoard() {
        RunningTime += Time.deltaTime;
        ScoreTime = RunningTime - SavedTime;
        Minutes = Mathf.RoundToInt(ScoreTime / 60.0f);
        Seconds = Mathf.RoundToInt(ScoreTime % 60.0f);
        if (DisplayTimeExpended.isActiveAndEnabled)
        {
            //DisplayTimeExpended.text = "Time Expended: " + RunningTime.ToString();
            DisplayTimeExpended.text = DisplayTimeExpendedEditorSet + RunningTime.ToString();
        }
        
        //DisplayScoreTime.text = "Score Time: " + ScoreTime.ToString();
        DisplayScoreTime.text = DisplayScoreTimeEditorSet + Minutes.ToString("00") + ":" + Seconds.ToString("00");
        DisplayLooseParts.text = DisplayLoosePartsEditorSet + LooseParts.Count.ToString();
        DisplayUnanswered.text = DisplayUnansweredEditorSet + Unanwsered.Count.ToString();

    }
}
