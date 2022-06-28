using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public GameObject dLight;

    public Light[] CencterLight;
    public Light[] DoorLight;
    bool isbump;
    public AudioClip bgm;

    // Start is called before the first frame update
    void Start()
    {
        isbump = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isbump = true;
            print("active1");
            BGMPlayer.Instance.Change(bgm);
            dLight.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (isbump == true)
        {
            for (int i = 0; i < 16; i++)
            {
               CencterLight[i].GetComponent<Light>().color = new Color(0.254717f, 0.001201498f, 0.001201498f, 1f);
            }

            for (int i = 0; i < 4; i++)
            {
                DoorLight[i].GetComponent<Light>().color = new Color(1f, 0, 0, 1f);
            }
        }
    }
}
    
