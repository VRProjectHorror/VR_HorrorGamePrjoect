using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCC : MonoBehaviour
{
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        Vector2 Rpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        cc.Move((this.transform.forward * Rpos.y * Time.deltaTime * 2f));

        //this.transform.Translate(this.transform.forward * Rpos.y * Time.deltaTime * 2f);
        this.transform.Rotate(this.transform.up * Lpos.x * Time.deltaTime * 50f);
    }
}
