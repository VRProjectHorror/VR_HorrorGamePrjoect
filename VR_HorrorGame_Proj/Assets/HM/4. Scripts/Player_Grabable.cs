using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Grabable : MonoBehaviour
{
    public Transform grabpos;
    GameObject grabObj;

    bool isGrab = false;
    bool isContact = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GrabObj();
        print(grabObj);
    }

    private void GrabObj()
    {
        if(isContact == true && isGrab == false && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
        {
            grabObj.transform.SetParent(grabpos);

            isGrab = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GrabPos") == true && isGrab == false)
        {

            print("TriggerEnter");
            isContact = true;
            grabObj = other.gameObject;

            if(isGrab == false)
            {
                OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);

                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("GrabPos") ==true && isGrab == false)
        {
            print("TriggerExit");
            isContact = false;
            grabObj = null;
        }
    }
}
