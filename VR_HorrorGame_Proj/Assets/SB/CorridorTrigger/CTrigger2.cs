using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger2 : MonoBehaviour
{
    public GameObject[] RotaterB;   //열려야하는 캐비넷들의 배열
    public GameObject[] ArmB;       //팔 배열
    Quaternion COpen;               //캐비넷 열리는 각도
    Transform RotateAction;         //캐비넷의 Transform 값
    Transform ArmMove;              //팔의 Transform 값
    bool isOpenB;
    bool isShowB;
    public GameObject checkB;
    public GameObject ActiveLightB;
    public AudioClip openSound;

    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y축값 지정
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
                RotateAction = RotaterB[i].transform; //배열의 트랜스폼 값을 로테이트에 줌
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.fixedDeltaTime * 10);
            }
            if (checkB.transform.rotation.eulerAngles.y == 190) //체크 대상의 y로테이션값이 190도 이상일때 멈춘다.
            {
                isOpenB = false;
                print(isOpenB);
            }
        }

        if (isShowB == true)
        {
            for (int r = 0; r < 9; r++)
            {
                ArmMove = ArmB[r].transform; //배열의 트랜스폼 값을 로테이트에 줌
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
                isShowB = false;   
            }
        }
    }
}
