using UnityEngine;

namespace Lottery
{
    [System.Serializable]
    public struct LotteryChanceChangeModeTable
    {
        [SerializeField, Header("確率変動状態移行ゲーム数周期天井")] private int _maxChanceModeCount;
        [SerializeField, Header("確率変動状態移行に必要なゲーム数周期")] private int[] _chanceModeGameCount;
        
        /// <summary>確率変動状態移行に必要なゲーム数</summary>
        public int[] ChanceModeGameCount => _chanceModeGameCount;

        /// <summary>確率変動状態移行ゲーム数周期天井</summary>
        public int MaxChanceModeCount => _maxChanceModeCount;
        
        public LotteryChanceChangeModeTable(LotteryChanceChangeModeTable table)
        {
            _chanceModeGameCount = table.ChanceModeGameCount;
            _maxChanceModeCount = table.MaxChanceModeCount;
        }
    }
}