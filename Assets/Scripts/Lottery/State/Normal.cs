using UnityEngine;

namespace Lottery.State
{
    public class Normal : IState
    {
        private readonly ChanceManager _chanceManager;

        public Normal(ChanceManager chanceManager)
        {
            _chanceManager = chanceManager;
        }
        public void Enter()
        {
            Debug.Log("NormalStateEnter");
        }

        public void Update()
        {
            if (_chanceManager.LotteryTable.DirectFiver <= _chanceManager.RandomValue)
            {
                
            }
            else if (_chanceManager.LotteryTable.FiverChallenge <= _chanceManager.RandomValue)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.FiverChance);
            }
        }

        public void Exit()
        {
            Debug.Log("NormalStateExit");
        }
    }
}