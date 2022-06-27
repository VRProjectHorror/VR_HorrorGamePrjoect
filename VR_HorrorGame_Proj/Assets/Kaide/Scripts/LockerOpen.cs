using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//락커 문이 열린다.
public class LockerOpen : MonoBehaviour
{
    Quaternion doorAngle;
    public float openAngle = -160f;
    public float closeAngle = 0f;
    public float closeSpeed;
    public float openSpeed;

    public float setOpen;

    public bool doorState = false; // 문 상태 확인용 변수
    public Transform door;   

    public AudioClip openSound;
    public AudioClip openSoundL;
    public AudioClip closeSound;

    AudioSource source;

    private void Awake()
    {
        setOpen = 1.5f;
        source = GetComponentInChildren<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        //문 열리는 최대 각
        doorAngle = Quaternion.AngleAxis(openAngle, Vector3.up); 
       
    }

    // Update is called once per frame
    void Update()
    {
        // 문 열리게 하는 함수 
        DoorRotate();

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    openSpeed = 0.5f;
        //    Open(openSpeed);
        //}
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    Close();
        //}
    }

    public void Open(float newOpenSpeed)
    {
        //이벤트 발생 시 문 열리는 속도 변경
        openSpeed = newOpenSpeed;
        doorState = true;
        if (openSpeed == setOpen)
        {
            source.PlayOneShot(openSoundL);
        }
        else
        {
            source.PlayOneShot(openSound);
        }
        Debug.Log("열림");
    }

    public void Close()
    {
        doorState = false;
        source.PlayOneShot(closeSound);
        Debug.Log("닫힘");
    }

    public void OpenCloseRepeat()
    {
        StartCoroutine(IEOpenCloseRepeat());
    }

    IEnumerator IEOpenCloseRepeat()
    {
        for (int i = 0; i < 3; i++)
        {
            Open(10f); // 문 열리는 속도가 10f
            yield return new WaitForSeconds(0.3f); //0.3초 후에 닫힘
            Close();
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void DoorRotate()
    {
        //
        if (doorState)
        {
            doorAngle = Quaternion.AngleAxis(openAngle, Vector3.up);
            door.localRotation = Quaternion.Lerp(door.localRotation, doorAngle, Time.deltaTime * openSpeed);
            
        }
        else
        {
            doorAngle = Quaternion.AngleAxis(closeAngle, Vector3.up);
            door.localRotation = Quaternion.Lerp(door.localRotation, doorAngle, Time.deltaTime * closeSpeed);
           
        }
        
    }

}
