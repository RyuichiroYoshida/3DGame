namespace Lottery.State
{
    public class Normal : IState
    {
        private ChanceManager _chanceManager;
        private float _randomValue;

        public Normal(ChanceManager chanceManager)
        {
            _chanceManager = chanceManager;
        }

        public void Enter()
        {
        }

        public void Update()
        {
            if (_chanceManager.IsChanceChangeMode || _chanceManager.IsMaxChanceMode)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.FiverChance);
                return;
            }
            _randomValue = _chanceManager.RandomValue;
            if (_chanceManager.LotteryTable.DirectFiver >= _randomValue)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Fiver);
                return;
            }

            if (_chanceManager.LotteryTable.FiverChallenge >= _randomValue)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.FiverChance);
                return;
            }

            if (_chanceManager.LotteryTable.MedalBonus >= _randomValue)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Bonus);
            }
        }

        public void Exit()
        {
            _chanceManager.IsChanceChangeMode = false;
        }
    }
}