using UnityEngine;

public class MedalSetParent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Medal"))
        {
            collision.transform.SetParent(transform);
        }
    }
}