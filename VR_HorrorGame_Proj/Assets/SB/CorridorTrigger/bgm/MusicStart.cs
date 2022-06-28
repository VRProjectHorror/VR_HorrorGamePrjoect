using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour
{
    // Inspector ������ ǥ���� ������� �̸�
    public string bgmName = "";

    private GameObject CamObject;

    void Start()
    {
        CamObject = GameObject.Find("OVRCameraRig");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            CamObject.GetComponent<BGMmanager>().PlayBGM(bgmName);
    }
}