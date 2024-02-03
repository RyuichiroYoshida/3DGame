using Lottery.State;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Lottery
{
    public class ChanceManager : MonoBehaviour
    {
        [SerializeField] private LotteryTable _lotteryTable;
        private StateMachine _stateMachine;
        [Header("デバッグ用")]
        [SerializeField] private Text _nowStateText;
        [SerializeField] private float _randomValue;

        public float RandomValue => _randomValue;
        public StateMachine StateMachine => _stateMachine;
        public LotteryTable LotteryTable => _lotteryTable;

        private void Awake()
        {
            _stateMachine = new StateMachine(this);
            _lotteryTable = new LotteryTable(_lotteryTable);
        }

        private void Start()
        {
            _stateMachine.Initialize(_stateMachine.Normal);
            _stateMachine.StateChanged += StateView;
            _stateMachine.StateUpdate();
        }

        public void PlayGame()
        {
            _randomValue = Random.Range(1f, 101f);
            _stateMachine.StateUpdate();
        }

        private void StateView(IState state)
        {
            _nowStateText.text = state?.GetType().Name;
        }
    }
}