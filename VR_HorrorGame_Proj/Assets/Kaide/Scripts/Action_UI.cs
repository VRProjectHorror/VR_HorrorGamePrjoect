using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Action_UI : MonoBehaviour
{
    RaycastHit hit;
    public LineRenderer lr;
    public float maxDis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, maxDis) == true)
        {            
            //Raycast에 닿으면 라인렌더러 작동
            lr.SetPosition(1, new Vector3(0, 0, hit.distance));

            //RTouch IndexTrigger를 누르면 
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
            {
                print(hit.collider.tag);
                //판별
                if (hit.collider.CompareTag("Start"))
                {
                    Debug.Log("Start");
                    Title.instance.gameStart();
                }
                else if (hit.transform.tag == "Quit")
                {
                    Debug.Log("Quit");
                    //Title.instance.gameQuit();
                }
               
            }

        }
    }
}
