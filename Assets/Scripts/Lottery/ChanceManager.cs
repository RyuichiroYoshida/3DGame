using UnityEngine;

namespace Lottery
{
    public class ChanceManager : MonoBehaviour
    {
        [SerializeField] private LotteryTable _lotteryTable;
        public float RandomValue { get; private set; }
        public StateMachine StateMachine { get; }
        public LotteryTable LotteryTable => _lotteryTable;

        private void Start()
        {
            StateMachine.Initialize(StateMachine.Normal);
        }

        public void PlayGame()
        {
            RandomValue = Random.Range(1, 101);
        }
    }
}