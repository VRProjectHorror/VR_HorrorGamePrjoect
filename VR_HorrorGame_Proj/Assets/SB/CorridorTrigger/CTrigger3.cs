using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger3 : MonoBehaviour
{
    public GameObject[] RotaterC;   //열려야하는 캐비넷들의 배열
    public GameObject[] ArmC;       //팔 배열
    Quaternion COpen;               //캐비넷 열리는 각도
    Transform RotateAction;         //캐비넷의 Transform 값
    Transform ArmMove;              //팔의 Transform 값
    bool isOpenC, isShowC;
    public GameObject checkC;
    public AudioClip openSound;
    public GameObject ActiveLightC;
    public GameObject ActiveLightD;

    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y축값 지정
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
                RotateAction = RotaterC[i].transform; //배열의 트랜스폼 값을 로테이트에 줌
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.deltaTime * 10);

                if (checkC.transform.rotation.eulerAngles.y == 190) //체크 대상의 y로테이션값이 190도 이상일때 멈춘다.
                {
                    isOpenC = false;
                }
            }
        }

        if (isShowC == true)
        {
            for (int r = 0; r < 14; r++)
            {
                ArmMove = ArmC[r].transform; //배열의 트랜스폼 값을 로테이트에 줌
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
                isShowC = false;
            }
        }
       
    }
}
