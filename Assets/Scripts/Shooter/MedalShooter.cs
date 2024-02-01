using UnityEngine;

public class MedalShooter : MonoBehaviour
{
    [SerializeField] private Transform _middleTrans;
    [SerializeField] private Transform _endTrans;
    [SerializeField] private int _rendererMiddlePoint = 10;
    [SerializeField] private GameObject _medalPrefab;
    private Vector3 _startPos;
    private Vector3 _middlePos;
    private Vector3 _endPos;
    
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _startPos = transform.position;
        _middlePos = _middleTrans.position;
        _endPos = _endTrans.position;

        var totalPoints = _rendererMiddlePoint + 2;
        _lineRenderer.positionCount = totalPoints;
        _lineRenderer.SetPosition(0, _startPos);
        for (var i = 1; i <= _rendererMiddlePoint; i++)
        {
            var t = i / ((float)totalPoints - 1);
            var mPos = CreateCurve(_startPos, _middlePos, _endPos, t);
            _lineRenderer.SetPosition(i, mPos);
        }

        _lineRenderer.SetPosition(totalPoints - 1, _endPos);
    }

    private Vector3 CreateCurve(Vector3 start, Vector3 middle, Vector3 end, float t)
    {
        var q0 = Vector3.Lerp(start, middle, t);
        var q1 = Vector3.Lerp(middle, end, t);
        var q2 = Vector3.Lerp(q0, q1, t);
        return q2;
    }

    public void ShootMedal()
    {
        var obj = MedalObjectPool.Instance.Pool.Get();
        obj.transform.position = transform.position;
        obj.transform.rotation = Quaternion.Euler(90 + Random.Range(-20, 21), 0, 0);
        obj.TryGetComponent(out Rigidbody rb);
        rb.AddForce((_middlePos - _startPos) * 11, ForceMode.Impulse);
        StageManager.Instance.AddGameCount();
    }
}