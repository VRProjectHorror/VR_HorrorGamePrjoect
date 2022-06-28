using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Glitch : MonoBehaviour
{
    public static Player_Glitch instance;

    public GameObject glitch;
    Material mat;
    MeshRenderer meshmat;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mat = glitch.GetComponent<Material>();
        meshmat = glitch.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGlitch(float glitchTime)
    {
        glitch.SetActive(true);

        Invoke("FalseGlitch", glitchTime);
    }

    void FalseGlitch()
    {
        glitch.SetActive(false);
    }
}
