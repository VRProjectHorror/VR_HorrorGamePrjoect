using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    // Inspector 에표시할 배경음악 목록
    public BgmType[] BGMList;

    private AudioSource BaseMusic;
    private string NowBGMname = "";

    void Start()
    {
        BaseMusic = gameObject.AddComponent<AudioSource>();
        BaseMusic.loop = true;
        if (BGMList.Length > 0) PlayBGM(BGMList[0].name);
        PlayBGM("First");
    }

    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;

        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BaseMusic.clip = BGMList[i].audio;
                BaseMusic.Play();
                NowBGMname = name;
            }
    }
  
}
