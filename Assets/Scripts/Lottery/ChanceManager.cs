using Lottery.State;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Lottery
{
    public class ChanceManager : MonoBehaviour
    {
        [SerializeField] private int _lotteryStartCount;
        [SerializeField] private LotteryTable _lotteryTable;
        private StateMachine _stateMachine;
        [Header("デバッグ用")]
        [SerializeField] private Text _nowStateText;
        [SerializeField] private float _randomValue;
        [SerializeField] private int _gameCount;

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
            var startState = _stateMachine.Normal;
            _stateMachine.Initialize(startState);
            StateView(startState);
            _stateMachine.StateChanged += StateView;
        }

        public void PlayGame()
        {
            _gameCount++;
            if (_gameCount >= _lotteryStartCount)
            {
                _randomValue = Random.Range(1f, 101f);
                _stateMachine.StateUpdate();
                _gameCount = 0;
            }
        }

        private void StateView(IState state)
        {
            _nowStateText.text = state?.GetType().Name;
        }
    }
}