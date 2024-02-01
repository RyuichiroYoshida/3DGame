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
            Debug.Log("FiverStateEnter");
        }

        public void Update()
        {
            if (_chanceManager.LotteryTable.FiverContinue <= _chanceManager.RandomValue)
            {
                
            }
        }

        public void Exit()
        {
            Debug.Log("FiverStateExit");
        }
    }
}