using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [SerializeField] private int _stageBetCount = 1;
    [SerializeField] private int _startCredit = 100;
    public int StageBetCount => _stageBetCount;
    public int StartCredit => _startCredit;
}