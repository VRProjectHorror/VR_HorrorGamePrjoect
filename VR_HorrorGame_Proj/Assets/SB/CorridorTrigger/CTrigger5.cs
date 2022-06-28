using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger5 : MonoBehaviour
{
    public GameObject[] RotaterE;   //열려야하는 캐비넷들의 배열
    public GameObject[] ArmE;       //팔 배열
    Quaternion COpen;               //캐비넷 열리는 각도
    Transform RotateAction;         //캐비넷의 Transform 값
    Transform ArmMove;              //팔의 Transform 값
    bool isOpenE;
    bool isShowE;
    public GameObject checkE;
    public AudioClip openSound;

    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y축값 지정
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
                RotateAction = RotaterE[i].transform; //배열의 트랜스폼 값을 로테이트에 줌
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.fixedDeltaTime * 10);
            }
            if (checkE.transform.rotation.eulerAngles.y == 190) //체크 대상의 y로테이션값이 190도 이상일때 멈춘다.
            {
                isOpenE = false;
            }
        }

        if (isShowE == true)
        {
            for (int r = 0; r < 7; r++)
            {
                ArmMove = ArmE[r].transform; //배열의 트랜스폼 값을 로테이트에 줌
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
                isShowE = false;
            }
        }
    }
}
