using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ����ĳ��Ʈ�� ���۹�ư�� �ε����� �ε��� Ʈ���Ÿ� ������ �����÷��̾����� �̵��ϰ�
// ����ĳ��Ʈ�� �����ư�� �ε����� �ε��� Ʈ���Ÿ� ������ ������ ����ȴ�.

public class Title : MonoBehaviour
{
    public static Title instance;

    private void Awake()
    {
        instance = this;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
       

    }

    public void gameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void gameQuit()
    {
        Application.Quit();
    }





}
