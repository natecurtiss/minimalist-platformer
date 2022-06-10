using System;

namespace MP.Utils
{
    public sealed class Timer
    {
        public event Action OnFinished;
        public float Time { get; private set; }
        public bool IsFinished { get; private set; } = true;

        public void Set(float t)
        {
            Time = t;
            if (t > 0)
                IsFinished = false;
        }

        public void Tick(float d)
        {
            Time -= d;
            if (!IsFinished && Time <= 0)
            {
                IsFinished = true;
                OnFinished?.Invoke();
            }
        }
    }
}