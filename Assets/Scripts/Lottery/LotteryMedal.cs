using UnityEngine;

namespace Lottery
{
    [System.Serializable]
    public struct LotteryMedal
    {
        [SerializeField, Header("フィーバー時の獲得メダル")] private int _fiverMedalCount;
        [SerializeField, Header("小当たり時の獲得メダル")] private int _winMedalCount;

        /// <summary>フィーバー時の獲得メダル</summary>
        public int FiverMedalCount => _fiverMedalCount;
        /// <summary>小当たり時の獲得メダル</summary>
        public int WinMedalCount => _winMedalCount;
        
        public LotteryMedal(LotteryMedal medal)
        {
            _fiverMedalCount = medal.FiverMedalCount;
            _winMedalCount = medal.WinMedalCount;
        }
    }
}