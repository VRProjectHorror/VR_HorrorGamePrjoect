using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 레이캐스트에 시작버튼이 부딪히고 인덱스 트리거를 누르면 게임플레이씬으로 이동하고
// 레이캐스트에 종료버튼이 부딪히고 인덱스 트리거를 누르면 게임이 종료된다.

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
