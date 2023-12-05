using UnityEngine;

public class CommonMedal : MedalBase
{
    [SerializeField] int _commonMedalScore = 10;

    private void Start()
    {
        base._score = _commonMedalScore;
    }
}