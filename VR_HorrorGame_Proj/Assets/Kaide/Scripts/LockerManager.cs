using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//락커가 열림
public class LockerManager : MonoBehaviour
{
    public LockerOpen[] lockers;
    public GameObject[] door;
    public float minTime;
    public float maxTime;    
    int active;    
   




    // Start is called before the first frame update
    void Start()
    {
        active = door.Length;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(IEActiveDoor());
        }
    }

    void SuffleDoor()
    {
        //spawn.Lenght만큼 랜덤을 돌려 index를 셔플한다
        for (int i = 0; i < active; i++)
        {
            int rValue = Random.Range(0, active);
            var temp = lockers[i];
            lockers[i] = lockers[rValue];
            lockers[rValue] = temp;
        }

    }

    IEnumerator IEActiveDoor()
    {        
        SuffleDoor(); //호출될 때 한 번 셔플    

        int count = Random.Range(1, active + 1);
        print(count);

        for (int i = 0; i < count; i++)
        {
            var locker = lockers[i];
            locker.OpenCloseRepeat();
            float activeTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(activeTime);
        }
    }

    //문 열고 닫히는 연출용
    


}

