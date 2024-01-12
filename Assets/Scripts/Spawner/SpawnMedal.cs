using UnityEngine;

namespace Spawner
{
    public class SpawnMedal : MonoBehaviour
    {
        public void MedalSpawn(GameObject medal)
        {
            var pos = this.transform.position;
            var randomZ = Random.Range(-8, 8);
            Instantiate(medal, new Vector3(pos.x, pos.y, pos.z + randomZ), Quaternion.identity);
        }
    }
}