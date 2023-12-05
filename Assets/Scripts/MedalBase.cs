using UnityEngine;

public class MedalBase : MonoBehaviour
{
    protected int _score;
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DestroyZone"))
        {
            ScoreCounter.Instance.AddScore(_score);
            Destroy(this.gameObject);
        }
    }
}