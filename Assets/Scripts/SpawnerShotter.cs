using UnityEngine;

public class SpawnerShotter : MonoBehaviour
{
    [SerializeField] private GameObject _medalPrefab;
    [SerializeField] private float _power = 10;
    [SerializeField] private float _coolTime = 1;
    private SpawnerInput _input;
    private float _timer = 0;

    private void Start()
    {
        _input = GetComponent<SpawnerInput>();
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_input.IsShotting && _timer <= 0)
        {
            Shot();
            _timer = _coolTime;
        }
    }

    private void Shot()
    {
        Instantiate(_medalPrefab, transform);
        Rigidbody rigidbody = GetComponentInChildren<Rigidbody>();
        rigidbody.AddForce(Vector3.forward * _power, ForceMode.Impulse);
    }
}