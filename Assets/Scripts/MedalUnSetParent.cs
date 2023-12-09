using UnityEngine;

public class MedalUnSetParent : MonoBehaviour
{
    [SerializeField] bool _isUse = false;
    private void OnCollisionExit(Collision collision)
    {
        if (!_isUse)
            return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            collision.transform.SetParent(null);
        }
    }
}