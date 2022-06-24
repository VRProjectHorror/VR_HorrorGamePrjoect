using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TextDrawer : MonoBehaviour
{
    /// <summary>
    /// 한 번에 이어지는 획
    /// 한 번에 이어서 그릴 수 있는 경우 한 획으로 친다
    /// </summary>
    [Serializable]
    public class Stroke
    {
        public List<Transform> positions = new List<Transform>();
    }

    public LineRenderer lineRendererPrefab;
    public List<Stroke> strokes;

    public float drawSpeed = 1.0f;
    public float strokeDelay = 0.1f;
    public float dotDiff = 0.05f;

    // 초기 글자 각 획에 해당하는 부분 찾기
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Stroke s = new Stroke();
            strokes.Add(s);
            var strokeTr = transform.GetChild(i);
            print(strokeTr.name);
            for (int j = 0; j < strokeTr.childCount; j++)
            {
                s.positions.Add(strokeTr.GetChild(j));
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            print("Draw text");
            DrawText();
        }
    }

    // 글자 쓰기
    public void DrawText()
    {
        StartCoroutine(IEDrawText());
    }

    IEnumerator IEDrawText()
    {
        for (int i = 0; i < strokes.Count; i++)
        {
            yield return new WaitForSeconds(strokeDelay);
            yield return IEDrawStroke(i);
        }
    }

    IEnumerator IEDrawStroke(int strokeIndex)
    {
        // 라인 렌더러 생성 - 초기 글자는 2개의 점으로 이루어져있다 가정
        var line = Instantiate(lineRendererPrefab);

        // 라인 초기화
        // 라인이 그려지지 않았으므로 포지션 겹쳐넣는다
        List<Vector3> linePoses = new List<Vector3>();
        var stroke = strokes[strokeIndex];
        var initPos = stroke.positions[0].position;
        line.SetPosition(0, initPos);
        linePoses.Add(initPos);
        var penPos = initPos;

        // 라인 그리기 - 현재 펜 위치 정해서 그린다 가정
        // 펜이 움직인다 가정하고 목표 위치(다음 획)로 점차 이동
        // 일정 위치까지 이동했을 경우 다음 목표로 이동시킨다
        for (int i = 1; i < stroke.positions.Count; i++)
        {
            linePoses.Add(linePoses[i-1]);
            line.positionCount = linePoses.Count;
            // 다음 획까지의 방향 구하기
            var dir = (stroke.positions[i].position - stroke.positions[i - 1].position).normalized;

            // 목표 지점까지 얼마 차이나지 않으면 계속 그림
            while (Vector3.Distance(penPos, stroke.positions[i].position) > dotDiff)
            {
                penPos += dir * drawSpeed * Time.deltaTime;
                linePoses[i] = penPos;
                line.SetPosition(i, penPos);
                yield return 0;
            }
        }
        yield return 0;
    }
}
