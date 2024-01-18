using UnityEngine;

namespace Medal
{
    public class MedalBase : MonoBehaviour
    {
        protected int _score;
        protected void OnCollisionEnter(Collision collision)
        {
            var spawnerPos = GameObject.FindWithTag("Spawner").GetComponent<Transform>().position;
            if (collision.gameObject.CompareTag("DestroyZone"))
            {
                ScoreCounter.Instance.AddScore(_score);
                this.transform.position = new Vector3(spawnerPos.x, spawnerPos.y, spawnerPos.z + Random.Range(-8, 8));
                MedalObjectPool.Instance.Pool.Release(this.gameObject);
            }
        }
    }
}