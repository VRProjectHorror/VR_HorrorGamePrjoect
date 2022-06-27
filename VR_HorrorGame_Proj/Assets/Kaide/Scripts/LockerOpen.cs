using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ŀ ���� ������.
public class LockerOpen : MonoBehaviour
{
    Quaternion doorAngle;
    public float openAngle = -160f;
    public float closeAngle = 0f;
    public float closeSpeed;
    public float openSpeed;

    public float setOpen;

    public bool doorState = false; // �� ���� Ȯ�ο� ����
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
        //�� ������ �ִ� ��
        doorAngle = Quaternion.AngleAxis(openAngle, Vector3.up); 
       
    }

    // Update is called once per frame
    void Update()
    {
        // �� ������ �ϴ� �Լ� 
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
        //�̺�Ʈ �߻� �� �� ������ �ӵ� ����
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
        Debug.Log("����");
    }

    public void Close()
    {
        doorState = false;
        source.PlayOneShot(closeSound);
        Debug.Log("����");
    }

    public void OpenCloseRepeat()
    {
        StartCoroutine(IEOpenCloseRepeat());
    }

    IEnumerator IEOpenCloseRepeat()
    {
        for (int i = 0; i < 3; i++)
        {
            Open(10f); // �� ������ �ӵ��� 10f
            yield return new WaitForSeconds(0.3f); //0.3�� �Ŀ� ����
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
