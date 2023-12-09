using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius = 5;
    [SerializeField] private float _power = 10;
    [SerializeField] private float _upPower = 3;

    public void Fire()
    {
        Debug.Log("Explosion!");
        var hitColliders = Physics.OverlapSphere(this.transform.position, _radius);
        foreach (var hit in hitColliders)
        {
            if (hit.TryGetComponent<Rigidbody>(out var rb))
                rb.AddExplosionForce(_power, this.transform.position, _radius, _upPower, ForceMode.Impulse);
        }
    }
}