using DG.Tweening;
using UnityEngine;
using static UnityEngine.Quaternion;
using static UnityEngine.Time;

namespace MP.Effects
{
    class TiltAngle : MonoBehaviour
    {
        [SerializeField] float _speed = 10f;
        [SerializeField] float _recovery = 0.1f;
        [SerializeField] float _angle = 30f;
        [SerializeField] float _tolerance = 2f;
    
        bool _isTilting;
        int _multiplier = 1;
        Tween _anim;

        Quaternion Target => AngleAxis(_angle * _multiplier, Vector3.forward);

        void Update()
        {
            if (_isTilting)
            {
                Rotate();
                CheckSwitch();
            }
        }

        void Rotate()
        {
            var smooth = Slerp(transform.rotation, Target, _speed * deltaTime);
            transform.rotation = smooth;
        }

        void CheckSwitch()
        {
            if (Angle(transform.rotation, Target) <= _tolerance)
                _multiplier *= -1;
        }

        public void Go()
        {
            _isTilting = true;
            _anim?.Kill();
        }

        public void Stop()
        {
            _isTilting = false;
            _anim = transform.DOLocalRotate(Vector3.zero, _recovery);
        }
    }
}