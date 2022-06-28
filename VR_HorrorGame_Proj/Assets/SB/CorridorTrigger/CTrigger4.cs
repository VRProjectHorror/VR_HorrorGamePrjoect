using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger4 : MonoBehaviour
{
    public GameObject[] RotaterD2;  //�������ϴ� ĳ��ݵ��� �迭
    public GameObject[] RotaterD3;
    public GameObject[] ArmD1;       //�� �迭
    public GameObject[] ArmD2;
    public GameObject[] ArmD3;
    Quaternion COpen;               //ĳ��� ������ ����
    Transform RotateAction;         //ĳ����� Transform ��
    Transform ArmMove;              //���� Transform ��
    bool isOpenD2, isOpenD3 = false;
    bool isShowD1, isShowD2, isShowD3 = false;

    public GameObject checkD2;
    public GameObject checkD3;
    public GameObject ActiveLightE;

    public AudioClip HightLightSound;
  
    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y�ప ����
       
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SFXPlayer.Instance.PlayNonSpatialSound(HightLightSound);
            isShowD1 = true;
            ActiveLightE.SetActive(true);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowD1 == true)
        {
           
            StartCoroutine("ArmRoutine");
        }
    }


    IEnumerator ArmRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        if (isShowD1 == true)   //ù��° �� �̵�
        {
            for (int r = 0; r < 7; r++)
            {
                ArmMove = ArmD1[r].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);

            }
            isShowD1 = false;   //ù��° ����
            isShowD2 = true;    //�ι�° �� ����
            isOpenD2 = true;    //�ι�° ĳ�̳� ����
        }

        if (isOpenD2 == true)
        {
          
            COpen = Quaternion.AngleAxis(-97, Vector3.up);
            for (int i = 0; i < 3; i++)
            {
              
                RotateAction = RotaterD2[i].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.deltaTime * 10);
               
            }
            yield return new WaitForSeconds(0.7f);
            isOpenD2 = false;   //�ι�° ĳ��� ����
            isOpenD3 = true;    //����° ĳ��� ����
          
        }
     
        if (isShowD2 == true)
        {
            for (int r = 0; r < 6; r++)
            {
                
                ArmMove = ArmD2[r].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
            }
            yield return new WaitForSeconds(0.7f);
            isShowD2 = false;   //�ι�° �� ����
            isShowD3 = true;    //����° �� ����
     
        }

        if (isOpenD3 == true)
        {
         
            COpen = Quaternion.AngleAxis(-97, Vector3.up);
            RotateAction = checkD3.transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
            RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.deltaTime * 10);
           
            if (checkD3.transform.rotation.eulerAngles.y == 190) //üũ ����� y�����̼ǰ��� 190�� �̻��϶� �����.
            {
                isOpenD3 = false;   //����° ĳ��� ����
            }
           
        }
      
        if (isShowD3 == true)
        {
            for (int c = 0; c < 7; c++)
            {
                ArmMove = ArmD3[c].transform; //�迭�� Ʈ������ ���� ������Ʈ�� ��
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
            }
            yield return new WaitForSeconds(0.5f);
            isShowD3 = false;
        }
    }
}
