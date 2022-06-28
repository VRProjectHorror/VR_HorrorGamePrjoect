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
            //Raycast�� ������ ���η����� �۵�
            lr.SetPosition(1, new Vector3(0, 0, hit.distance));

            //RTouch IndexTrigger�� ������ 
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) == true)
            {
                print(hit.collider.tag);
                //�Ǻ�
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
