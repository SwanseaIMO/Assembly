using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DestroyInteractableObject : MonoBehaviour {

    public void LockInSnap()
    {
        //this.GetComponent<VRTK_InteractableObject>().disableWhenIdle = false;
        //this.GetComponent<VRTK_InteractableObject>().enabled = false;
        Destroy(this.GetComponent<VRTK_InteractableObject>());
        
    }
}
