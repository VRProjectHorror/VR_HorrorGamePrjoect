using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger5 : MonoBehaviour
{
    public GameObject[] RotaterE;   //�������ϴ� ĳ��ݵ��� �迭
    public GameObject[] ArmE;       //�� �迭
    Quaternion COpen;               //ĳ��� ������ ����
    Transform RotateAction;         //ĳ����� Transform ��
    Transform ArmMove;              //���� Transform ��
    bool isOpenE;
    bool isShowE;
    public GameObject checkE;
    public AudioClip openSound;

    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y�ప ����
        isOpenE = false;
        isShowE = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SFXPlayer.Instance.PlayNonSpatialSound(openSound);
            isOpenE = true;
            isShowE = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenE == true)
        {
            for (int i = 0; i < 6; i++)
            {
                RotateAction = RotaterE[i].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.fixedDeltaTime * 10);
            }
            if (checkE.transform.rotation.eulerAngles.y == 190) //üũ ����� y�����̼ǰ��� 190�� �̻��϶� �����.
            {
                isOpenE = false;
            }
        }

        if (isShowE == true)
        {
            for (int r = 0; r < 7; r++)
            {
                ArmMove = ArmE[r].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
                isShowE = false;
            }
        }
    }
}
