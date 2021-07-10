using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Camera : MonoBehaviour
{
    private const int basicY = -20;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, Player.transform.position.y + basicY, this.transform.position.z);
    }
}
