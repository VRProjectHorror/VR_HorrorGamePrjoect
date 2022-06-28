using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger1 : MonoBehaviour
{
    public GameObject[] RotaterA;   //열려야하는 캐비넷들의 배열
    public GameObject[] ArmA;       //팔 배열
    Quaternion COpen;               //캐비넷 열리는 각도
    Transform RotateAction;         //캐비넷의 Transform 값
    Transform ArmMove;              //팔의 Transform 값
    bool isOpenA;
    bool isShowA;
    public GameObject checkA;
    public GameObject ActiveLightA;

    public AudioClip bgm;
    public AudioClip openSound;

    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y축값 지정
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
        if(isOpenA == true) // 캐비넷 열기
        {
            for (int i = 0; i < 7; i++)
            {
                
                RotateAction = RotaterA[i].transform; //배열의 트랜스폼 값을 로테이트에 줌
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.fixedDeltaTime * 10);
              
            }
            if (checkA.transform.rotation.eulerAngles.y == 190) //체크 대상의 y로테이션값이 190도 이상일때 멈춘다.
            {
                isOpenA = false;
                print(isOpenA);
            }

        }

        if (isShowA == true) //팔 이동
        {
            for (int r = 0; r < 11; r++)
            {
                ArmMove = ArmA[r].transform; //배열의 트랜스폼 값을 로테이트에 줌
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
                isShowA = false;
            }  
        }
    }
}
