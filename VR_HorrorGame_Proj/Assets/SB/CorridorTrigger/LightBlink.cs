using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{

    float time;          
    public GameObject[] OffLight;  // 라이트 배열
    bool LightSwitch;
   
    private void Awake()
    {

    }

    private void Update()
    { if (LightSwitch == true)
        {
            StartCoroutine("FlashNow");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LightSwitch = true;
        }
    }

    public IEnumerator FlashNow()
    {
        LightSwitch = false;
        
        for (int i = 0; i < 16; i++)
        {
            OffLight[i].GetComponent<Light>().enabled = true;
        }
        time = Random.Range(0.01f, 1f);
        yield return new WaitForSeconds(time);
        for (int i = 0; i < 16; i++)
        {
            OffLight[i].GetComponent<Light>().enabled = false;   //밝기 감소   
        }
        time = Random.Range(1f, 2f);
        yield return new WaitForSeconds(time);
        LightSwitch = true;
        yield return null;
    }
}
    
        
           
   
