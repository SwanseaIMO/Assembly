using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinMass : MonoBehaviour {

    private Rigidbody Rb;

    // Update is called once per frame
    public void AddMass()
    {
        Rb = GetComponent<Collider>().attachedRigidbody;
        Rb.mass = Rb.mass + 1.0f;
    }
}
