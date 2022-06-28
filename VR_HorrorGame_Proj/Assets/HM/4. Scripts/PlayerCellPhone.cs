using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCellPhone : MonoBehaviour
{
    public static PlayerCellPhone instance;

    AudioSource katalksound;

    public GameObject phone;
    Material phonemat;
    MeshRenderer phoneMesh;
    bool isPhoneOn = false;
    public bool isAlarmOn = false;
    public bool isTalkEnd = false;
    bool isSee1 = false;
    bool isSee2 = false;
    bool isSee3 = false;
    bool isUIClik = false;
    public Texture[] kakaotalk_Start;

    public Texture[] first_KakaoTalk;
    public Texture[] second_KakaoTalk;
    public Texture[] third_KakaoTalk;
    int textureslength;
    int countkakao = 1;
    
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
        katalksound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(isTalkEnd);
        if(isAlarmOn == true && isPhoneOn == false)
        {
            
        }


        if (OVRInput.GetDown(OVRInput.Button.Two) && isTalkEnd == true)
        {
            PhoneOff();
        }



    }

    void PhoneOn()
    {
        //Debug
            AlarmOn(1);
        //===============================

        isPhoneOn = true;
        phone.SetActive(true);

    }

    void PhoneOff()
    {
        isPhoneOn = false;
        isTalkEnd = false;
        phone.SetActive(false);

        action?.Invoke();
    }

    public void StartPhoneCoroutine(int num)
    {
        isTalkEnd = false;
        phone.SetActive(true);

        StartCoroutine(StartKakaoTalk(num));
    }

    public void CameAlarm()
    {
        katalksound.Play();
        StartCoroutine(Vibration(0.3f, 0.5f, 0.5f, OVRInput.Controller.All));

        //사운드 추가


        // UI 추가

    }

    public void AlarmOn(int num)
    {
        switch (num)
        {
            case 1:
                if(isSee1 == false)
                StartCoroutine(KakaoTalk(first_KakaoTalk));
                isSee1 = true;
                break;

            case 2:
                if (isSee2 == false)
                    StartCoroutine(KakaoTalk(second_KakaoTalk));
                isSee2 = true;
                break;

            case 3:
                if (isSee3 == false)
                    StartCoroutine(KakaoTalk(third_KakaoTalk));
                isSee3 = true;
                break;
        }
        isPhoneOn = true;
        isAlarmOn = false;
        isTalkEnd = true;
        countkakao++;
    }

    IEnumerator KakaoTalk(Texture[] kakaoImages)
    {
        

        yield return new WaitForSeconds(1f);
        textureslength = kakaoImages.Length;

        for (int i = 0; i < textureslength; i++)
        {
            katalksound.Play();
            StartCoroutine(Vibration(0.3f, 0.5f, 0.5f, OVRInput.Controller.All));

            phoneMesh.materials[1].SetTexture("_EmissionMap", kakaoImages[i]);

            //while (isPhoneOn == false)
            //{
            //    yield return null;
            //}

            yield return new WaitForSeconds(2f);

            
        }

    }

    IEnumerator StartKakaoTalk(int i)
    {
        phoneMesh.materials[1].SetTexture("_EmissionMap", kakaotalk_Start[i - 1]);
        yield return new WaitForSeconds(5f);
        AlarmOn(i);

        StopCoroutine("StartKakaoTalk");
    }

    IEnumerator Vibration(float waitTime, float frequenct, float amplitude, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequenct, amplitude, controller);
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
