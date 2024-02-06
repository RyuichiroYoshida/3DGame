namespace Lottery.State
{
    public class FiverChance : IState
    {
        private ChanceManager _chanceManager;
        private int _challengeCount = 0;

        public FiverChance(ChanceManager chanceManager)
        {
            _chanceManager = chanceManager;
        }
        public void Enter()
        {
            AudioManager.Instance.ChanceAudio.Play();
        }

        public void Update()
        {
            _challengeCount++;
            if (_chanceManager.IsMaxChanceMode)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Fiver);
                return;
            }
            if (_chanceManager.LotteryTable.FiverChance >= _chanceManager.RandomValue)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Fiver);
                return;
            }

            if (_chanceManager.LotteryTable.FiverChallengeLimit < _challengeCount)
            {
                _chanceManager.StateMachine.TransitionTo(_chanceManager.StateMachine.Normal);
            }
        }

        public void Exit()
        {
            _chanceManager.IsMaxChanceMode = false;
            AudioManager.Instance.ChanceAudio.Stop();
        }
    }
}