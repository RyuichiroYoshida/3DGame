using UnityEngine;

namespace Lottery.State
{
    public class Fiver : IState
    {
        private ChanceManager _chanceManager;

        public Fiver(ChanceManager chanceManager)
        {
            _chanceManager = chanceManager;
        }
        public void Enter()
        {
            
        }

        public void Update()
        {
            _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Normal);
            // if (_chanceManager.LotteryTable.FiverContinue <= _chanceManager.RandomValue)
            // {
            //     
            // }
        }

        public void Exit()
        {
            
        }
    }
}