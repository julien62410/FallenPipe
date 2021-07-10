using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Camera : MonoBehaviour
{
    public const int basicY = -33;
    public const int basicZ = -70;
    public GameObject Player;

    private void Start()
    {
        this.transform.position = new Vector3(0, basicY, basicZ);
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithTheBall();
        GetTouchInput();
    }

    private void MoveWithTheBall ()
    {
        this.transform.position = new Vector3(this.transform.position.x, Player.transform.position.y + basicY, this.transform.position.z);
    }

    private void GetTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("input");
            
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -basicZ));
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hitInfo;

            Debug.Log((touchPosition));

            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(("hit"));
                Debug.Log(hitInfo.collider.gameObject.name);
            }
            
        }
    }
}
