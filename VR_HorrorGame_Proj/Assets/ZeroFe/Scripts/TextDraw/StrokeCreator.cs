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

    //마우스 드래그로 글자 그릴 좌표 구하기
    //- 마우스 누르면 시작으로 봄.
    //- 마우스 드래그하면 일정 간격을 기준으로 점을 생성
    //- 이전 점과의 distance 차이를 이용해 새 점을 추가
    //- (디버그) 마우스 드래그 시작 시 라인 렌더러 추가.
    //    점 추가에 따라 라인 렌더러로 그리는 기능 필요
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
                // Quad에 대고 그리므로 Quad와 위치가 같으면 Line
                stroke.position = hit.point + Vector3.back * normalDiff;

                // Stroke 내의 초기 점
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
            // 마우스 드래그하면 일정 간격을 기준으로 점을 생성
            // - 이전 점과의 distance 차이를 이용해 새 점을 추가
            Ray ray = _main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var hitPoint = hit.point + Vector3.back * normalDiff;

                // 라인 렌더의 마지막 점의 위치를 hit.point로 재설정
                line.SetPosition(line.positionCount - 1, hitPoint);
                if (Vector3.Distance(dots[dots.Count - 1].transform.position, hitPoint) > distanceDiff)
                {
                    // 다음 점을 그린다
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
