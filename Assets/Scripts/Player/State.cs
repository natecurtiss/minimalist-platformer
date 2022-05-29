namespace MP.Player
{
    abstract class State
    {
        public abstract void Init(PlayerController player);
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}