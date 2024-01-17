using UnityEngine;
using UnityEngine.Pool;

namespace Medal
{
    public class MedalBase : MonoBehaviour
    {
        protected int _score;
        protected void OnCollisionEnter(Collision collision)
        {
            var spawnerPos = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Transform>().position;
            if (collision.gameObject.CompareTag("DestroyZone"))
            {
                ScoreCounter.Instance.AddScore(_score);
                var random = Random.Range(-4, 4);
                this.transform.position = new Vector3(spawnerPos.x, spawnerPos.y, spawnerPos.z + random);
                MedalObjectPool.Instance.Pool.Release(this.gameObject);
            }
        }
    }
}