using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_1 : Message
{
    public AudioSource clapSoundSource;
    public AudioClip clapSound;

    protected override void Trigger()
    {
        print("ù ��° ���� ����");
        clapSoundSource.clip = clapSound;
        clapSoundSource.loop = true;
        clapSoundSource.Play();
    }
}
