using System;

namespace Utils
{
    class Timer
    {
        public event Action OnFinished;
    
        float _time;
        bool _isFinished;

        public void Set(float t)
        {
            _time = t;
            if (t > 0)
                _isFinished = false;
        }

        public void Tick(float d)
        {
            _time -= d;
            if (!_isFinished && _time <= 0)
            {
                _isFinished = true;
                OnFinished?.Invoke();
            }
        }
    }
}