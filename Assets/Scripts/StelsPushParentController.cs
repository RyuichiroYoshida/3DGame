using UnityEngine;

public class StelsPushParentController : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private bool _isUse = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (!_isUse)
            return;

        if (collider.gameObject.CompareTag("Medal"))
        {
            collider.transform.SetParent(_parent);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (!_isUse)
            return;

        if (collider.gameObject.CompareTag("Medal"))
        {
            collider.transform.SetParent(null);
        }
    }
}