using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCellPhone : MonoBehaviour
{
    public static PlayerCellPhone instance;

    public GameObject R_Controller;
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

    // ������ X��ư ( Button.one ) �� ������ ȭ�� UI�� ��
    // ������ Y��ư ( Button.two ) �� ������ ȭ�� UI�� ����

    // Start is called before the first frame update
    void Start()
    {
        phonemat = phone.GetComponent<Material>();
        phoneMesh = phone.GetComponent<MeshRenderer>();
        //�����
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

    public void AlarmOn(int num)
    {
        switch (num)
        {
            case 1:
                StartCoroutine(KakaoTalk(first_KakaoTalk));
                break;

            case 2:
                StartCoroutine(KakaoTalk(second_KakaoTalk));
                break;

            case 3:
                StartCoroutine(KakaoTalk(third_KakaoTalk));
                break;
        }
    }

    IEnumerator KakaoTalk(Texture[] kakaoImages)
    {
        textureslength = kakaoImages.Length;

        for (int i = 0; i < textureslength; i++)
        {
            StartCoroutine(Vibration(0.3f, 0.5f, 0.5f, OVRInput.Controller.All));

            phoneMesh.materials[1].SetTexture("_EmissionMap", kakaoImages[i]);

            while (isPhoneOn == false)
            {
                yield return null;
            }

            yield return new WaitForSeconds(2f);
        }

    }

    IEnumerator Vibration(float waitTime, float frequenct, float amplitude, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequenct, amplitude, controller);
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
