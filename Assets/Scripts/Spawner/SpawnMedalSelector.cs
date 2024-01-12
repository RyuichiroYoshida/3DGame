using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class SpawnMedalSelector : MonoBehaviour
    {
        [SerializeField] private SpawnMedal _medalSpawner;
        [SerializeField] private List<GameObject> _medalPrefabs;
        private int _spawnCount = 0;

        public void SelectMedal()
        {
            var random = Random.Range(0, 2);
            _medalSpawner.MedalSpawn(_medalPrefabs[random]);
        }
    }
}