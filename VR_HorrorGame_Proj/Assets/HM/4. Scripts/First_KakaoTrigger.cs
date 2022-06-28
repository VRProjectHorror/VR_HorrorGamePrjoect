using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_KakaoTrigger : MonoBehaviour
{
    AudioSource katalksound;

    bool isPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        katalksound = GetComponent<AudioSource>();
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

           PlayerCellPhone.instance.StartPhoneCoroutine(1);

            //Debug
            Player_Glitch.instance.SetGlitch(0.5f);

        }
    }
}
