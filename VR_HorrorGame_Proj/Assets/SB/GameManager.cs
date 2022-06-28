using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] ArmSetting;
    

    // Start is called before the first frame update
    void Start()
    {
       GameObject ArmSetting = GameObject.Find("AlienArmAnimated");
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
