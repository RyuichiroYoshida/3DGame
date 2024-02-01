using UnityEngine;

namespace Lottery.State
{
    public class FiverChance : IState
    {
        private readonly ChanceManager _chanceManager;

        public FiverChance(ChanceManager chanceManager)
        {
            _chanceManager = chanceManager;
        }
        public void Enter()
        {
            Debug.Log("FiverChanceStateEnter");
        }

        public void Update()
        {
            if (_chanceManager.LotteryTable.FiverChance <= _chanceManager.RandomValue)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Fiver);
            }
        }

        public void Exit()
        {
            Debug.Log("FiverChanceStateExit");
        }
    }
}