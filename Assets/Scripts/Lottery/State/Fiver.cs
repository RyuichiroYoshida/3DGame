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
            var source = AudioManager.Instance.FiverBGM;
            if (!source.isPlaying)
            {
                source.Play();
            }

            SpawnFiverMedal();
            _chanceManager.IsFiver = true;
        }

        public void Update()
        {
            if (_chanceManager.LotteryTable.FiverContinue >= _chanceManager.RandomValue)
            {
                SpawnFiverMedal();
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
            AudioManager.Instance.FiverBGM.Stop();
        }

        private void SpawnFiverMedal()
        {
            AudioManager.Instance.FiverDropMedal.Play();
            for (var i = 0; i < _chanceManager.LotteryMedal.FiverMedalCount; i++)
            {
                _chanceManager.SpawnMedal.MedalSpawn(MedalObjectPool.Instance.Pool);
            }
        }
    }
}