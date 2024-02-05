using UnityEngine;

namespace Lottery
{
    [System.Serializable]
    public struct LotteryTable
    {
        [SerializeField, Header("フィーバー直当たり確率%")] private float _directFiver;
        [SerializeField, Header("通常時フィーバーチャンス突入確率%")] private float _fiverChallenge;
        [SerializeField, Header("フィーバーチャンス突破確率%")] private float  _fiverChance;
        [SerializeField, Header("フィーバーチャンスチャレンジ上限回数")] private int _fiverChallengeLimit;
        [SerializeField, Header("フィーバー継続確率%")] private float _fiverContinue;
        [SerializeField, Header("小当たり確率%")] private float _medalBonus;
        
        /// <summary>フィーバー直当たり確率%</summary>
        public float DirectFiver => _directFiver;
        /// <summary>通常時フィーバーチャンス突入確率%</summary>
        public float FiverChallenge => _fiverChallenge;
        /// <summary>フィーバーチャンス突破確率%</summary>
        public float FiverChance => _fiverChance;
        /// <summary>フィーバーチャンスチャレンジ上限回数</summary>
        public int FiverChallengeLimit => _fiverChallengeLimit;
        /// <summary>フィーバー継続確率%</summary>
        public float FiverContinue => _fiverContinue;
        /// <summary>小当たり確率%</summary>
        public float MedalBonus => _medalBonus;

        public LotteryTable(LotteryTable table)
        {
            _directFiver = table.DirectFiver;
            _fiverChallenge = table.FiverChallenge;
            _fiverChance = table.FiverChance;
            _fiverChallengeLimit = table.FiverChallengeLimit;
            _fiverContinue = table.FiverContinue;
            _medalBonus = table.MedalBonus;
        }
    }
}