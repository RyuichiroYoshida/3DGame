namespace Lottery.State
{
    public class Bonus : IState
    {
        private ChanceManager _chanceManager;

        public Bonus(ChanceManager chanceManager)
        {
            _chanceManager = chanceManager;
        }
        
        public void Enter()
        {
            AudioManager.Instance.BonusAudio.Play();
            for (var i = 0; i < _chanceManager.LotteryMedal.WinMedalCount; i++)
            {
                _chanceManager.SpawnMedal.MedalSpawn(MedalObjectPool.Instance.Pool);
            }
        }

        public void Update()
        {
            _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Normal);
        }

        public void Exit()
        {
            AudioManager.Instance.BonusAudio.Stop();
        }
    }
}