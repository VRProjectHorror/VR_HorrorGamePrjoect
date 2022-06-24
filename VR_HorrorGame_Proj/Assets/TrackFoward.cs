using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackFoward : MonoBehaviour
{
    public GameObject CenterEyeCamera;
    public GameObject ForwardDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation = CenterEyeCamera.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

       
    }
}
