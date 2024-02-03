using UnityEngine;

namespace Lottery
{
    [System.Serializable]
    public struct LotteryTable
    {
        [SerializeField, Tooltip("フィーバー直当たり確率")] private float _directFiver;
        [SerializeField, Tooltip("フィーバーチャンス突入確率")] private float _fiverChallenge;
        [SerializeField, Tooltip("フィーバーチャンス突破確率")] private float  _fiverChance;
        [SerializeField, Tooltip("フィーバー継続確率")] private float _fiverContinue;
        [SerializeField, Tooltip("小当たり確率")] private float _medalBonus;
        
        public float DirectFiver => _directFiver;
        public float FiverChallenge => _fiverChallenge;
        public float FiverChance => _fiverChance;
        public float FiverContinue => _fiverContinue;
        public float MedalBonus => _medalBonus;

        public LotteryTable(LotteryTable table)
        {
            _directFiver = table.DirectFiver;
            _fiverChallenge = table.FiverChallenge;
            _fiverChance = table.FiverChance;
            _fiverContinue = table.FiverContinue;
            _medalBonus = table.MedalBonus;
        }
    }
}