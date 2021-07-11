using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_Camera : MonoBehaviour
{
    private bool isPlaying = false;

    public const int basicY = -22;
    public const int basicZ = -50;

    public GameObject player;
    public Button tapToStart;

    private void Start()
    {
        this.transform.position = new Vector3(0, basicY, basicZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            MoveWithTheBall();
            GetTouchInput();
        }
        else
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        if (Input.touchCount > 0)
        {
            player.GetComponent<Rigidbody>().useGravity = true;
            tapToStart.gameObject.SetActive(false);
            isPlaying = true;
        }
    }

    private void MoveWithTheBall ()
    {
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y + basicY, this.transform.position.z);
    }

    private void GetTouchInput()
    {
        if (Input.touchCount > 0)
        {            
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, -basicZ));
                Ray ray = new Ray(this.transform.position, touchPosition - this.transform.position);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.transform.CompareTag("Intersection"))
                    {
                        hitInfo.transform.parent.GetComponentInChildren<SC_Lever>().SwitchRotation();
                    }

                    else if (hitInfo.transform.CompareTag("Lever"))
                    {
                        hitInfo.transform.GetComponent<SC_Lever>().SwitchRotation();
                    }
                }
            }
            
        }
    }
}
