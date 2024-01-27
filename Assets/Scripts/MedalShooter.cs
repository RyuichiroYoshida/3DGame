using UnityEngine;

public class MedalShooter : MonoBehaviour
{
    [SerializeField] private LayerMask _stageLayer;
    [SerializeField] private Transform _middleTrans;
    [SerializeField] private Transform _endTrans;
    [SerializeField] private Transform _markerTrans;
    
    [SerializeField] private int _rendererMiddlePoint = 10;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        var startPos = transform.position;
        var middlePos = _middleTrans.position;
        var endPos = _endTrans.position;

        Debug.DrawLine(middlePos, endPos, Color.magenta);
        if (Physics.Linecast(middlePos, endPos, out var hit, _stageLayer))
        {
            endPos = hit.point;
        }
        
        var totalPoints = _rendererMiddlePoint + 2;
        _lineRenderer.positionCount = totalPoints;
        _lineRenderer.SetPosition(0, startPos);
        for (var i = 1; i <= _rendererMiddlePoint; i++)
        {
            var t = i / ((float)totalPoints - 1);
            var mPos = CreateCurve(startPos, middlePos, endPos, t);
            _lineRenderer.SetPosition(i, mPos);
        }

        _lineRenderer.SetPosition(totalPoints - 1, endPos);
        _markerTrans.position = endPos;
    }

    private Vector3 CreateCurve(Vector3 start, Vector3 middle, Vector3 end, float t)
    {
        var q0 = Vector3.Lerp(start, middle, t);
        var q1 = Vector3.Lerp(middle, end, t);
        var q2 = Vector3.Lerp(q0, q1, t);
        return q2;
    }
}