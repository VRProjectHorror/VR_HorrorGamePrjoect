using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCellPhone : MonoBehaviour
{
    public static PlayerCellPhone instance;

    public GameObject phone;
    Material phonemat;
    MeshRenderer phoneMesh;
    bool isPhoneOn = false;
    public bool isAlarmOn = false;

    public Texture[] first_KakaoTalk;
    public Texture[] second_KakaoTalk;
    public Texture[] third_KakaoTalk;
    int textureslength;
    int textureslength2;
    int textureslength3;

    public System.Action action;

    public void Awake()
    {
        instance = this;
    }
    
    // 오른쪽 X버튼 ( Button.one ) 을 누르면 화면 UI가 뜸
    // 오른쪽 Y버튼 ( Button.two ) 을 누르면 화면 UI가 닫힘

    // Start is called before the first frame update
    void Start()
    {
        phonemat = phone.GetComponent<Material>();
        phoneMesh = phone.GetComponent<MeshRenderer>();
        //디버그
        Invoke("AlarmOn", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && isPhoneOn == false)
        {
            PhoneOn();
        }
        else if (OVRInput.GetDown(OVRInput.Button.Two) && isPhoneOn == true)
        {
            PhoneOff();
        }


       
    }

    void PhoneOn()
    {
        isPhoneOn = true;
        phone.SetActive(true);
    }

    void PhoneOff()
    {
        isPhoneOn = false;
        phone.SetActive(false);

        action?.Invoke();
    }

    void AlarmOn()
    {

        StartCoroutine(First_KakaoTalk());

    }

    IEnumerator First_KakaoTalk()
    {
        textureslength = first_KakaoTalk.Length;

        for(int i = 0; i < textureslength; i++)
        {
            OVRInput.SetControllerVibration(0.05f, 0.1f, OVRInput.Controller.All);

            phoneMesh.materials[1].SetTexture("_EmissionMap", first_KakaoTalk[i]);

            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator Second_KakaoTalk()
    {
        textureslength2 = second_KakaoTalk.Length;

        for (int i = 0; i < textureslength2; i++)
        {
            OVRInput.SetControllerVibration(0.05f, 0.1f, OVRInput.Controller.All);

            phoneMesh.materials[1].SetTexture("_EmissionMap", second_KakaoTalk[i]);

            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator Third_KakaoTalk()
    {
        textureslength3 = third_KakaoTalk.Length;

        for (int i = 0; i < textureslength3; i++)
        {
            OVRInput.SetControllerVibration(0.05f, 0.1f, OVRInput.Controller.All);

            phoneMesh.materials[1].SetTexture("_EmissionMap", third_KakaoTalk[i]);

            yield return new WaitForSeconds(2f);
        }
    }
}
