using UnityEngine;

namespace Medal
{
    public class RareMedal : MedalBase
    {
        [SerializeField] int _rareMedalScore = 10;
        private void Start()
        {
            base._score = _rareMedalScore;
            base._rigidbody = GetComponent<Rigidbody>();
        }
    }
}