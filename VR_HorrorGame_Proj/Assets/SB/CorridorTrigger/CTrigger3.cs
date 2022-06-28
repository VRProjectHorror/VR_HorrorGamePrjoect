using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger3 : MonoBehaviour
{
    public GameObject[] RotaterC;   //�������ϴ� ĳ��ݵ��� �迭
    public GameObject[] ArmC;       //�� �迭
    Quaternion COpen;               //ĳ��� ������ ����
    Transform RotateAction;         //ĳ����� Transform ��
    Transform ArmMove;              //���� Transform ��
    bool isOpenC, isShowC;
    public GameObject checkC;
    public AudioClip openSound;
    public GameObject ActiveLightC;
    public GameObject ActiveLightD;

    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y�ప ����
        isOpenC = false;
        isShowC = false;
     

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SFXPlayer.Instance.PlayNonSpatialSound(openSound);
            isOpenC = true;
            isShowC = true;
            ActiveLightC.SetActive(true);
            ActiveLightD.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenC == true)
        {

            for (int i = 0; i < 4; i++)
            {
                RotateAction = RotaterC[i].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.deltaTime * 10);

                if (checkC.transform.rotation.eulerAngles.y == 190) //üũ ����� y�����̼ǰ��� 190�� �̻��϶� �����.
                {
                    isOpenC = false;
                }
            }
        }

        if (isShowC == true)
        {
            for (int r = 0; r < 14; r++)
            {
                ArmMove = ArmC[r].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
                isShowC = false;
            }
        }
       
    }
}
