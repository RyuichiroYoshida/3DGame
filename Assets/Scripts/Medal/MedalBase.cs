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
                BombController.Instance.AddBombGauge(_score);
                MedalObjectPool.Instance.Pool.Release(this.gameObject);
                StageManager.Instance.AddMedalGetCount();
                _isSound = false;
            }
            else if (collision.gameObject.CompareTag("UpperStage") && _isSound == false)
            {
                _isSound = true;
                AudioManager.Instance.AMedalDrop();
            }
        }
        protected void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("UpperStage"))
            {
                _rigidbody.AddForce(new Vector3(-3f, 0f, 0f), ForceMode.Impulse);
            }
        }
    }
}