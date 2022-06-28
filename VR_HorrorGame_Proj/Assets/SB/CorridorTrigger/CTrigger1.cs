using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger1 : MonoBehaviour
{
    public GameObject[] RotaterA;   //�������ϴ� ĳ��ݵ��� �迭
    public GameObject[] ArmA;       //�� �迭
    Quaternion COpen;               //ĳ��� ������ ����
    Transform RotateAction;         //ĳ����� Transform ��
    Transform ArmMove;              //���� Transform ��
    bool isOpenA;
    bool isShowA;
    public GameObject checkA;
    public GameObject ActiveLightA;

    public AudioClip bgm;
    public AudioClip openSound;

    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y�ప ����
        isOpenA = false;
        isShowA = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BGMPlayer.Instance.Change(bgm);
            SFXPlayer.Instance.PlayNonSpatialSound(openSound);
            isOpenA = true;
            isShowA = true;
            ActiveLightA.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpenA == true) // ĳ��� ����
        {
            for (int i = 0; i < 7; i++)
            {
                
                RotateAction = RotaterA[i].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.fixedDeltaTime * 10);
              
            }
            if (checkA.transform.rotation.eulerAngles.y == 190) //üũ ����� y�����̼ǰ��� 190�� �̻��϶� �����.
            {
                isOpenA = false;
                print(isOpenA);
            }

        }

        if (isShowA == true) //�� �̵�
        {
            for (int r = 0; r < 11; r++)
            {
                ArmMove = ArmA[r].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
                isShowA = false;
            }  
        }
    }
}
