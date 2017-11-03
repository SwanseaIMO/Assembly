using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.Events;

public class NameTheBone : MonoBehaviour {

    private AnatomyGameController GameController;
    private VRTK_ObjectTooltip toolTipOfObject;
    public VRTK_RadialMenu vRTK_RadialMenu;
    public GameObject MainParent;
    public string PreferedName; 
    public VRTK_InteractableObject SphereVRTKController;

    public int numberOfChoices = 4;
    private int AcctualNumberOfChoices = 4;
    
    public float TimeAddedForCorrectAnswer;
    public float TimeLostForIncorrectAnswer;

    public void CorrectAnswer()
    {

        //flash dark green and black Tick

        // switch to Colour green 
        toolTipOfObject.containerColor = Color.green;

        //Change name
        toolTipOfObject.UpdateText(PreferedName);



        // play ding

        //
        //add score

        // add from score 
        GameController.SavedTime += TimeAddedForCorrectAnswer; 

        // remove object from the controller
        GameController.Unanwsered.Remove(this.gameObject);

        // disable
        //transformVRTK_InteractableObject
        SphereVRTKController.disableWhenIdle = false;
        SphereVRTKController.enabled = false;
    }

    public void InCorrentAnswer()
    {
        //flash red green 
        toolTipOfObject.containerColor = Color.red;
        toolTipOfObject.ResetTooltip();

        // set up rest to clear
        Invoke("ChangeBack", 1);

        // play dong

        //
        //Loose score
        // add from score 
        GameController.SavedTime -= TimeLostForIncorrectAnswer;
    }

    public void ChangeBack()
    {
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString("E7E7E7FF", out myColor);
        // switch to Colour 
        toolTipOfObject.containerColor = myColor;
        toolTipOfObject.ResetTooltip();
    }

    // Use this for initialization
    void Start() {
        GameController = GameObject.Find("GameController").GetComponent<AnatomyGameController>();
        GameController.Unanwsered.Add(this.gameObject);

        if(PreferedName == null || PreferedName == "")
        {
            PreferedName = MainParent.name;
        }

        toolTipOfObject = this.GetComponent<VRTK_ObjectTooltip>();

        Invoke("setup", 0.05f);
    }

    void setup() {

        int i = 0;
        bool setCorrect = false;
        float RandomValue;
        GameObject GameObjectForName;
        NameTheBone NameForChoices;


        List<string> listOfOtherAnswers = new List<string>();
        AcctualNumberOfChoices = Mathf.Min(GameController.LooseParts.Count, numberOfChoices);

        vRTK_RadialMenu.buttons.Clear();
        while ( i < AcctualNumberOfChoices)
        {
            RandomValue = Random.value;
            if ((RandomValue < 0.25 || i == 3) && !setCorrect)
            {
                setCorrect = true;
                GameObjectForName = this.gameObject;
                //ClickEvent.AddListener(CorrectAnswer);
            }
            else
            {
                GameObjectForName = this.gameObject;
                while (GameObjectForName == this.gameObject)
                {
                    
                    GameObjectForName = GameController.Unanwsered[Random.Range(0, GameController.Unanwsered.Count)];
                    NameForChoices = GameObjectForName.GetComponent<NameTheBone>();
                    if (PreferedName == NameForChoices.PreferedName)
                    {

                    }
                    else if (listOfOtherAnswers.Contains(NameForChoices.PreferedName))
                    {
                        GameObjectForName = this.gameObject;
                    }
                    else
                    {
                        listOfOtherAnswers.Add(NameForChoices.PreferedName);
                    }
                }
               // ClickEvent.AddListener(InCorrentAnswer);
            }

            vRTK_RadialMenu.buttons.Add(new VRTK_RadialMenu.RadialMenuButton());
            NameForChoices = GameObjectForName.GetComponent<NameTheBone>();
            vRTK_RadialMenu.buttons[i].ButtonText = NameForChoices.PreferedName;
            vRTK_RadialMenu.buttons[i].iconOrText = true;
            if (PreferedName == NameForChoices.PreferedName)
            {
                vRTK_RadialMenu.buttons[i].OnClick.AddListener(delegate { this.CorrectAnswer(); });
                //var action = (UnityAction)Delegate.CreateDelegate(typeof(UnityAction), go, targetinfo, false);
                //vRTK_RadialMenu.buttons[i].OnClick.AddListener(CorrectAnswer);
            }
            else
            {
                //vRTK_RadialMenu.buttons[i].OnClick.AddListener(InCorrentAnswer);
                vRTK_RadialMenu.buttons[i].OnClick.AddListener(delegate { this.InCorrentAnswer(); });

            }
            i++;
        }
        vRTK_RadialMenu.RegenerateButtons();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
