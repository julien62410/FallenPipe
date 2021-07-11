using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PipeTrigger : MonoBehaviour
{
    public float velocityMultiplier = 1;

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.velocity *= velocityMultiplier;
    }
}
