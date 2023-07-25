namespace BehaviourTreeTests.Utility 
{
    public class CooldownTimer
    {
        private float _maxCooldownAmount;
        private float _currentCooldown;

        public CooldownTimer()
        {
            SetTimer(0f);
        }

        public CooldownTimer(float cooldownAmount)
        {
            SetTimer(cooldownAmount);
        }

        public void SetTimer(float cooldownAmount)
        {
            _maxCooldownAmount = cooldownAmount;
            _currentCooldown = _maxCooldownAmount;
        }

        public void Tick(float timeStep)
        {
            if (timeStep <= _currentCooldown)
                _currentCooldown -= timeStep;
            else
                _currentCooldown = 0f;
        }

        public bool TimerEnded() => _currentCooldown == 0f;

        public float GetRemainingTime() => _currentCooldown;

        public bool StartedTimer() => _currentCooldown != 0f;
    }
}

