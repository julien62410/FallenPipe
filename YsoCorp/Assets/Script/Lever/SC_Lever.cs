using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SC_Lever : MonoBehaviour
{
    public bool angleADroite = true;
    private bool isFirstAngle = true;

    private int firstAngle = -120;
    private int secondAngle = -55;

    private void Start()
    {
        isFirstAngle = angleADroite;
    }

    private void Update()
    {
        if (angleADroite != isFirstAngle)
        {
            SwitchRotation();
        }
    }

    public void SwitchRotation()
    {
        this.transform.Rotate(0, 0, (isFirstAngle ? (secondAngle - firstAngle) : (firstAngle - secondAngle)));
        isFirstAngle = !isFirstAngle;
        angleADroite = isFirstAngle;
    }
}