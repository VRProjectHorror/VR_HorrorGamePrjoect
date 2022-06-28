using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_KakaoTrigger : MonoBehaviour
{
    bool isPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (isPlayed)
        {
            return;
        }

        if (other.tag == "Player")
        {
            isPlayed = true;

            PlayerCellPhone.instance.isAlarmOn = true;

            PlayerCellPhone.instance.CameAlarm();

            PlayerCellPhone.instance.StartPhoneCoroutine(3);
        }
    }
}
