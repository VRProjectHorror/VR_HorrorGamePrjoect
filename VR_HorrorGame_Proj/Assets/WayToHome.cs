using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WayToHome : MonoBehaviour
{
    public GameObject Player;
    public Transform wayToHome;

    public GameObject uI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.transform.position = wayToHome.transform.position;

            Invoke("TheEnd", 1f);
        }
    }

    void TheEnd()
    {
        uI.SetActive(true);
        Invoke("GoTitle", 3f);
    }

    void GoTitle()
    {
        SceneManager.LoadScene(0);
    }
}
