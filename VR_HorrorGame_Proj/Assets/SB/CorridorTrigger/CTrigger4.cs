using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrigger4 : MonoBehaviour
{
    public GameObject[] RotaterD2;  //열려야하는 캐비넷들의 배열
    public GameObject[] RotaterD3;
    public GameObject[] ArmD1;       //팔 배열
    public GameObject[] ArmD2;
    public GameObject[] ArmD3;
    Quaternion COpen;               //캐비넷 열리는 각도
    Transform RotateAction;         //캐비넷의 Transform 값
    Transform ArmMove;              //팔의 Transform 값
    bool isOpenD2, isOpenD3 = false;
    bool isShowD1, isShowD2, isShowD3 = false;

    public GameObject checkD2;
    public GameObject checkD3;
    public GameObject ActiveLightE;

    public AudioClip HightLightSound;
  
    // Start is called before the first frame update
    void Start()
    {
        COpen = Quaternion.AngleAxis(-97, Vector3.up);  //y축값 지정
       
       
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
        if (isShowD1 == true)   //첫번째 팔 이동
        {
            for (int r = 0; r < 7; r++)
            {
                ArmMove = ArmD1[r].transform; //배열의 트랜스폼 값을 로테이트에 줌
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);

            }
            isShowD1 = false;   //첫번째 종료
            isShowD2 = true;    //두번째 팔 시작
            isOpenD2 = true;    //두번째 캐미넷 시작
        }

        if (isOpenD2 == true)
        {
          
            COpen = Quaternion.AngleAxis(-97, Vector3.up);
            for (int i = 0; i < 3; i++)
            {
              
                RotateAction = RotaterD2[i].transform; //배열의 트랜스폼 값을 로테이트에 줌
                RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.deltaTime * 10);
               
            }
            yield return new WaitForSeconds(0.7f);
            isOpenD2 = false;   //두번째 캐비넷 종료
            isOpenD3 = true;    //세번째 캐비넷 시작
          
        }
     
        if (isShowD2 == true)
        {
            for (int r = 0; r < 6; r++)
            {
                
                ArmMove = ArmD2[r].transform; //배열의 트랜스폼 값을 로테이트에 줌
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
            }
            yield return new WaitForSeconds(0.7f);
            isShowD2 = false;   //두번째 팔 종료
            isShowD3 = true;    //세번째 팔 시작
     
        }

        if (isOpenD3 == true)
        {
         
            COpen = Quaternion.AngleAxis(-97, Vector3.up);
            RotateAction = checkD3.transform; //배열의 트랜스폼 값을 로테이트에 줌
            RotateAction.localRotation = Quaternion.Lerp(RotateAction.localRotation, COpen, Time.deltaTime * 10);
           
            if (checkD3.transform.rotation.eulerAngles.y == 190) //체크 대상의 y로테이션값이 190도 이상일때 멈춘다.
            {
                isOpenD3 = false;   //세번째 캐비넷 종료
            }
           
        }
      
        if (isShowD3 == true)
        {
            for (int c = 0; c < 7; c++)
            {
                ArmMove = ArmD3[c].transform; //배열의 트랜스폼 값을 로테이트에 줌
                ArmMove.transform.localPosition = new Vector3(0, 0, 0);
            }
            yield return new WaitForSeconds(0.5f);
            isShowD3 = false;
        }
    }
}
