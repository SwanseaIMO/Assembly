using UnityEngine;
using System.Collections;
using VRTK;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;


public class DisableParentSnappingAndChildGrabScript : MonoBehaviour {

    private AnatomyGameController GameController;
    private VRTK_InteractableObject InteractableObjectController;

    // Use this for initialization
    void Start()
    {
        GameObject[] GameObjectCollidersToIgnore;
        GameController = GameObject.Find("GameController").GetComponent<AnatomyGameController>();
        GameController.LooseParts.Add(this.gameObject);
        InteractableObjectController = this.GetComponent<VRTK_InteractableObject>();
        //GameObjectCollidersToIgnore = GameObject.FindGameObjectsWithTag("IgnoreWhileTouching");
        //InteractableObjectController.ignoredColliders = new Collider[GameObjectCollidersToIgnore.Length];
        //for (int i = 0; i <  GameObjectCollidersToIgnore.Length; i++)
        //{
        //    Collider[] Coliders;
        //    Coliders = GameObjectCollidersToIgnore[i].GetComponents<Collider>();
        //    for(int j = 0; j < Coliders.Length; j++)
        //    {
        //        InteractableObjectController.ignoredColliders[i] = Coliders[j];
        //    }
        //}
        
    }

    public void LockInSnap()
    {
        Debug.Log(this.name);
        Destroy(this.GetComponent<Rigidbody>());
        //SetAllCollidersStatus(false);
        //SetAllCollidersStatus(true);
        this.GetComponent<VRTK_InteractableObject>().disableWhenIdle = false;
        this.GetComponent<VRTK_InteractableObject>().enabled = false;
        //Destroy(this.GetComponent<VRTK_InteractableObject>());
        //Destroy(this.GetComponent<VRTK_FixedJointGrabAttach>());
        //Destroy(this.GetComponent<VRTK_SwapControllerGrabAction>());
        //Destroy(this.GetComponent<VRTK_InteractHaptics>());

        GameController.LooseParts.Remove(this.gameObject);
    }

    public void DisableSnapZone() // not used
    {
        Destroy(this.GetComponent<Rigidbody>());
        SetAllCollidersStatus(false);
        Destroy(this.GetComponent<VRTK_InteractableObject>());
        //Destroy(this.GetComponent<VRTK_BaseGrabAttach>();
        //Destroy(this.GetComponent("VRTK_SwapControllerGabAction"));
    }

    public void SetAllCollidersStatus(bool status)
    {
        foreach (Collider c in this.GetComponents<Collider>())
        {
            c.enabled = status;
        }
    }
}
