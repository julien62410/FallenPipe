using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PipeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.velocity *= 3;
    }
}
