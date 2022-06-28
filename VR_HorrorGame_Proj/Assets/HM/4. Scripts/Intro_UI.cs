using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro_UI : MonoBehaviour
{
    public Text startUIText;
    public Text closeUIText;

    bool isBtnOn = false;
    public bool isKakaoend = false;
    // Start is called before the first frame update
    void Start()
    {
        startUIText.gameObject.SetActive(true);
        closeUIText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (isBtnOn == false && OVRInput.GetDown(OVRInput.Button.One))
        {
            startUIText.gameObject.SetActive(false);

            PlayerCellPhone.instance.StartPhoneCoroutine(1);
            isBtnOn = true;
        }

        if(PlayerCellPhone.instance.isTalkEnd == true)
        {
            closeUIText.gameObject.SetActive(true);
        }
        else if(isBtnOn == true && OVRInput.GetDown(OVRInput.Button.Two))
        {
            closeUIText.gameObject.SetActive(false);
        }
    }
}
