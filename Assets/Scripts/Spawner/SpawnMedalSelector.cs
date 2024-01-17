using System.Collections.Generic;
using UnityEngine;


public class SpawnMedalSelector : MonoBehaviour
{
    [SerializeField] private SpawnMedal _medalSpawner;
    [SerializeField] private List<GameObject> _medalPrefabs;

    public void SelectMedal()
    {
        var random = Random.Range(0, 2);
        _medalSpawner.MedalSpawn(MedalObjectPool.Instance.Pool);
    }
}