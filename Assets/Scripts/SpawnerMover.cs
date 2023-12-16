using UnityEngine;

public class SpawnerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Rigidbody _rigidbody;
    private SpawnerInput _input;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<SpawnerInput>();
    }
    private void FixedUpdate()
    {
        if (_input.MoveValue == 0)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }
        _rigidbody.velocity = new Vector3(0, 0, _speed * _input.MoveValue);
    }
}