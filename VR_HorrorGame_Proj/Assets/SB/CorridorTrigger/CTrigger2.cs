using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger2 : MonoBehaviour
{
    public GameObject[] RotaterB;   //�������ϴ� ĳ��ݵ��� �迭
    public GameObject[] ArmB;       //�� �迭
    Quaternion COpen;               //ĳ��� ������ ����
    Transform RotateAction;         //ĳ����� Transform ��
    Transform ArmMove;              //���� Transform ��
    bool isOpenB;
    bool isShowB;
    public GameObject checkB;
    public GameObject ActiveLightB;
    public AudioClip openSound;

    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y�ప ����
        isOpenB = false;
        isShowB = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SFXPlayer.Instance.PlayNonSpatialSound(openSound);
            isOpenB = true;
            isShowB = true;
            ActiveLightB.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenB == true)
        {
            for (int i = 0; i < 7; i++)
            {
                RotateAction = RotaterB[i].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.fixedDeltaTime * 10);
            }
            if (checkB.transform.rotation.eulerAngles.y == 190) //üũ ����� y�����̼ǰ��� 190�� �̻��϶� �����.
            {
                isOpenB = false;
                print(isOpenB);
            }
        }

        if (isShowB == true)
        {
            for (int r = 0; r < 9; r++)
            {
                ArmMove = ArmB[r].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
                isShowB = false;   
            }
        }
    }
}
