using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [SerializeField] private int _stageBetCount = 1;
    [SerializeField] private int _startCredit = 100;
    
    public int StageBetCount => _stageBetCount;
    public int StartCredit => _startCredit;
    public static int GameCount { get; private set; }
    public static int MedalGetCount { get; private set; }

    public void AddGameCount()
    {
        GameCount++;
    }

    public void AddMedalGetCount()
    {
        MedalGetCount++;
    }
}
