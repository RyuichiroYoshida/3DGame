using Lottery.State;
using UnityEngine;

namespace Lottery
{
    public class ChanceManager : MonoBehaviour
    {
        [SerializeField] private string _nowState;
        [SerializeField] private LotteryTable _lotteryTable;
        public float RandomValue { get; private set; }
        public StateMachine StateMachine { get; }
        public LotteryTable LotteryTable => _lotteryTable;

        private void Start()
        {
            StateMachine.Initialize(StateMachine.Normal);
            StateMachine.StateChanged += StateView;
        }

        public void PlayGame()
        {
            RandomValue = Random.Range(1, 101);
        }

        private void StateView(IState state)
        {
            _nowState = state.GetType().Name;
        }
    }
}