using UnityEngine;

public class SpawnerInput : MonoBehaviour
{
    [SerializeField] private float _moveValue = 0;
    [SerializeField] private bool _isShotting = false;
    public float MoveValue => _moveValue;
    public bool IsShotting => _isShotting;
    private void Update()
    {
        _moveValue = Input.GetAxisRaw("Horizontal");
        _isShotting = Input.GetButton("Jump");
    }
}