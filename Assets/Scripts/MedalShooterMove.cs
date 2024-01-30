using UnityEngine;

public class MedalShooterMove : MonoBehaviour
{
    [SerializeField] private float _speedHorizontal = 5;
    [SerializeField] private Rigidbody _rigidbody;
    
    public void MoveShooterHorizontal(float horizontal)
    {
        var pos = transform.position;
        if (pos.z >= 8)
        {
            transform.position = new Vector3(pos.x, pos.y, 7.9f);
        }
        else if (pos.z <= -8)
        {
            transform.position = new Vector3(pos.x, pos.y, -7.9f);
        }
        else
        {
            var speed = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(speed.x, speed.y, horizontal * _speedHorizontal);
        }
    }
    public void ResetVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}