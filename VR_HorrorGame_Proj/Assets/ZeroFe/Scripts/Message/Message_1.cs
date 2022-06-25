using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_1 : Message
{
    public Transform spawnPos;
    public GameObject playerChaserPrefab;

    protected override void Trigger()
    {
        print("첫 번째 쪽지 실행");
        //Instantiate(playerChaserPrefab, spawnPos.position + Vector3.up, Quaternion.identity);
    }
}
