using System;
using Lottery.State;

namespace Lottery
{
    [Serializable]
    public class StateMachine
    {
        public IState CurrentState { get; private set; }
        public Normal Normal { get; }
        public FiverChance FiverChance { get; }
        public Fiver Fiver { get; }

        public event Action<IState> StateChanged; 
        
        public StateMachine(ChanceManager chanceManager)
        {
            Normal = new Normal(chanceManager);
            FiverChance = new FiverChance(chanceManager);
            Fiver = new Fiver(chanceManager);
        }

        public void Initialize(IState startState)
        {
            CurrentState = startState;
            startState.Enter();
            StateChanged?.Invoke(startState);
        }

        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
            StateChanged?.Invoke(nextState);
        }

        public void StateUpdate()
        {
            CurrentState?.Update();
        }
    }
}