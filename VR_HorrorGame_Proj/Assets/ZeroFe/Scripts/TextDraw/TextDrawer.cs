using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TextDrawer : MonoBehaviour
{
    /// <summary>
    /// �� ���� �̾����� ȹ
    /// �� ���� �̾ �׸� �� �ִ� ��� �� ȹ���� ģ��
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

    // �ʱ� ���� �� ȹ�� �ش��ϴ� �κ� ã��
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

    // ���� ����
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
        // ���� ������ ���� - �ʱ� ���ڴ� 2���� ������ �̷�����ִ� ����
        var line = Instantiate(lineRendererPrefab);

        // ���� �ʱ�ȭ
        // ������ �׷����� �ʾ����Ƿ� ������ ���ĳִ´�
        List<Vector3> linePoses = new List<Vector3>();
        var stroke = strokes[strokeIndex];
        var initPos = stroke.positions[0].position;
        line.SetPosition(0, initPos);
        linePoses.Add(initPos);
        var penPos = initPos;

        // ���� �׸��� - ���� �� ��ġ ���ؼ� �׸��� ����
        // ���� �����δ� �����ϰ� ��ǥ ��ġ(���� ȹ)�� ���� �̵�
        // ���� ��ġ���� �̵����� ��� ���� ��ǥ�� �̵���Ų��
        for (int i = 1; i < stroke.positions.Count; i++)
        {
            linePoses.Add(linePoses[i-1]);
            line.positionCount = linePoses.Count;
            // ���� ȹ������ ���� ���ϱ�
            var dir = (stroke.positions[i].position - stroke.positions[i - 1].position).normalized;

            // ��ǥ �������� �� ���̳��� ������ ��� �׸�
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
