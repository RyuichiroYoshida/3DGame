using System;
using Lottery.State;

namespace Lottery
{
    [Serializable]
    public class StateMachine
    {
        private IState _currentState;
        public readonly Normal Normal;
        public readonly FiverChance FiverChance;
        public readonly Fiver Fiver;

        public event Action<IState> StateChanged; 
        
        public StateMachine(ChanceManager chanceManager)
        {
            Normal = new Normal(chanceManager);
            FiverChance = new FiverChance(chanceManager);
            Fiver = new Fiver(chanceManager);
        }

        public void Initialize(IState startState)
        {
            _currentState = startState;
            startState.Enter();
            StateChanged?.Invoke(startState);
        }

        public void TransitionTo(IState nextState)
        {
            _currentState.Exit();
            _currentState = nextState;
            nextState.Enter();
            StateChanged?.Invoke(nextState);
        }

        public void StateUpdate()
        {
            _currentState?.Update();
        }
    }
}