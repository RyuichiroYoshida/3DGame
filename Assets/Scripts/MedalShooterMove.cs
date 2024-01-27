using UnityEngine;

public class MedalShooterMove : MonoBehaviour
{
    [SerializeField] private float _speedHorizontal = 5;
    [SerializeField] private float _speedVertical = 3;
    [SerializeField] private Rigidbody _rigidbody;
    
    public void MoveShooterHorizontal(float horizontal)
    {
        var speed = _rigidbody.velocity;
        speed = new Vector3(speed.x + (horizontal * _speedHorizontal), speed.y);
    }
    public void MoveShooterVertical(float vertical)
    {
        var speed = _rigidbody.velocity;
        speed = new Vector3(speed.x, speed.y + (vertical * _speedVertical));
    }
}