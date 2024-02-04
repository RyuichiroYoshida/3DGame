using UnityEngine;

namespace Lottery
{
    [System.Serializable]
    public struct LotteryMedal
    {
        [SerializeField, Tooltip("フィーバー時の獲得メダル")] private int _fiverMedalCount;
        [SerializeField, Tooltip("小当たり時の獲得メダル")] private int _winMedalCount;

        public int FiverMedalCount => _fiverMedalCount;
        public int WinMedalCount => _winMedalCount;
        
        public LotteryMedal(LotteryMedal medal)
        {
            _fiverMedalCount = medal.FiverMedalCount;
            _winMedalCount = medal.WinMedalCount;
        }
    }
}