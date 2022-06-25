using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_1 : Message
{
    public AudioSource clapSoundSource;
    public AudioClip clapSound;

    protected override void Trigger()
    {
        print("첫 번째 쪽지 실행");
        clapSoundSource.clip = clapSound;
        clapSoundSource.loop = true;
        clapSoundSource.Play();
    }
}
