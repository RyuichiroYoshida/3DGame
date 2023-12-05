using UnityEngine;

public class MedalUnSetParent : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Medal"))
        {
            collision.transform.SetParent(null);
        }
    }
}