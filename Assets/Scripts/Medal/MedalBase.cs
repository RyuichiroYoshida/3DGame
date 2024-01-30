using UnityEngine;

namespace Medal
{
    [RequireComponent(typeof(Rigidbody))]
    public class MedalBase : MonoBehaviour
    {
        protected int _score;
        protected Rigidbody _rigidbody;
        private bool _isSound = false;

        protected void OnCollisionEnter(Collision collision)
        {
            var spawnerPos = GameObject.FindWithTag("Spawner").GetComponent<Transform>().position;
            if (collision.gameObject.CompareTag("DestroyZone"))
            {
                ScoreCounter.Instance.AddScore(_score);
                this.transform.position = new Vector3(spawnerPos.x, spawnerPos.y, spawnerPos.z + Random.Range(-8, 8));
                _rigidbody.velocity = Vector3.zero;
                FiverManager.Instance.FiverCheck();
                BombController.Instance.AddBombGauge(_score);
                MedalObjectPool.Instance.Pool.Release(this.gameObject);
                _isSound = false;
            }
            else if (collision.gameObject.CompareTag("Ground") && _isSound == false)
            {
                _isSound = true;
                AudioManager.Instance.AMedalDrop();
            }
        }
    }
}