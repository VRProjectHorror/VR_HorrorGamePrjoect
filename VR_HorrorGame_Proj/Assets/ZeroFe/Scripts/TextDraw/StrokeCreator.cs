using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokeCreator : MonoBehaviour
{
    private static float normalDiff = 0.2f;

    public GameObject dotPrefab;
    public float distanceDiff = 0.1f;

    [Header("Debug")] 
    public LineRenderer linePrefab;
    public Transform lineParent;
    private LineRenderer line;

    private Camera _main;

    private Transform stroke;
    private List<GameObject> dots;

    RaycastHit hit;

    void Start()
    {
        _main = Camera.main;
    }

    //���콺 �巡�׷� ���� �׸� ��ǥ ���ϱ�
    //- ���콺 ������ �������� ��.
    //- ���콺 �巡���ϸ� ���� ������ �������� ���� ����
    //- ���� ������ distance ���̸� �̿��� �� ���� �߰�
    //- (�����) ���콺 �巡�� ���� �� ���� ������ �߰�.
    //    �� �߰��� ���� ���� �������� �׸��� ��� �ʿ�
    void Update()
    {
        // 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Make Stroke");

                var go = new GameObject("Stroke");
                stroke = go.transform;
                // Quad�� ��� �׸��Ƿ� Quad�� ��ġ�� ������ Line
                stroke.position = hit.point + Vector3.back * normalDiff;

                // Stroke ���� �ʱ� ��
                AddDot(stroke.position);

                line = Instantiate(linePrefab);
                line.transform.SetParent(lineParent);
                line.positionCount = 2;
                line.SetPosition(0, stroke.position);
                line.SetPosition(1, stroke.position);
            }
        }

        if (Input.GetMouseButton(0) && stroke)
        {
            // ���콺 �巡���ϸ� ���� ������ �������� ���� ����
            // - ���� ������ distance ���̸� �̿��� �� ���� �߰�
            Ray ray = _main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var hitPoint = hit.point + Vector3.back * normalDiff;

                // ���� ������ ������ ���� ��ġ�� hit.point�� �缳��
                line.SetPosition(line.positionCount - 1, hitPoint);
                if (Vector3.Distance(dots[dots.Count - 1].transform.position, hitPoint) > distanceDiff)
                {
                    // ���� ���� �׸���
                    AddDot(hitPoint);
                    line.positionCount += 1;
                    line.SetPosition(line.positionCount - 1, hitPoint);
                }
            }
        }
    }

    void AddDot(Vector3 pos)
    {
        dots = new List<GameObject>();
        var dot = new GameObject("Dot");
        dot.transform.position = pos;
        dot.transform.parent = stroke;
        dots.Add(dot);
    }
}
