using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTL : MonoBehaviour
{
    //public Rigidbody player;
    public float speed;

    float dirX, dirZ;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 Lpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        //Vector2 Rpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        //this.transform.Translate(this.transform.forward * Rpos.y * Time.deltaTime * 1f);
        //this.transform.Rotate(this.transform.up * Lpos.x * Time.deltaTime * 45f);

        //VrMove();
        VRMove2();
    }

    //void VrMove()
    //{
    //    var joystickAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);

    //    float fixedY = player.position.y;

    //    player.position += (transform.right * joystickAxis.x + transform.forward * joystickAxis.y) * Time.deltaTime * speed;

    //    player.position = new Vector3(player.position.x, fixedY, player.position.z);
    //}

    void VRMove2()
    {
        dirX = 0;
        dirZ = 0;

        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            var absX = Mathf.Abs(coord.x);
            var absY = Mathf.Abs(coord.y);

            if (absX > absY)
            {
                if (coord.x > 0) { dirX = +1; }
                else { dirX = -1; }
            }
            else
            {
                if (coord.y > 0) { dirZ = +1; }
                else { dirZ = -1; }
            }
        }
        Vector3 movedir = new Vector3(dirX * 2, 0, dirZ * 3);
        transform.Translate(movedir * Time.deltaTime);


    }
}
