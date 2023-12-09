using UnityEngine;

public class MedalSetParent : MonoBehaviour
{
    [SerializeField] bool _isUse = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (!_isUse)
            return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            collision.transform.SetParent(transform);
        }
        else if (collision.gameObject.CompareTag("Medal"))
        {
            collision.transform.SetParent(transform);
        }
    }
}