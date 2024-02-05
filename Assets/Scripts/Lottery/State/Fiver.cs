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
            _chanceManager.IsFiver = true;
            for (var i = 0; i < _chanceManager.LotteryMedal.FiverMedalCount; i++)
            {
                _chanceManager.SpawnMedal.MedalSpawn(MedalObjectPool.Instance.Pool);
            }
        }

        public void Update()
        {
            if (_chanceManager.LotteryTable.FiverContinue >= _chanceManager.RandomValue)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Fiver);
            }
            else
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Normal);
            }
        }

        public void Exit()
        {
            ChanceChangeModeManager.ChanceGameCount = 0;
            _chanceManager.IsFiver = false;
        }
    }
}