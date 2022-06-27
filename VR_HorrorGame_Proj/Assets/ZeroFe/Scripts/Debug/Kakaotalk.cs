using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerCellPhone ����� Ŭ����
/// </summary>
public class Kakaotalk : MonoBehaviour
{
    public static Kakaotalk Instance { get; private set; }

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
        Instance = this;
    }

    // ������ X��ư ( Button.one ) �� ������ ȭ�� UI�� ��
    // ������ Y��ư ( Button.two ) �� ������ ȭ�� UI�� ����

    // Start is called before the first frame update
    void Start()
    {
        phoneMesh = phone.GetComponent<MeshRenderer>();
        phonemat = phoneMesh.material;
        //�����
        //Invoke("AlarmOn", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isPhoneOn)
            {
                PhoneOn();
            }
            else
            {
                PhoneOff();
            }
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
            phoneMesh.materials[1].SetTexture("_EmissionMap", kakaoImages[i]);

            while (isPhoneOn == false)
            {
                yield return null;
            }

            yield return new WaitForSeconds(2f);
        }

    }
}
