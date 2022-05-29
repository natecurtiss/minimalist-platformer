using DG.Tweening;
using UnityEngine;

namespace MP.Effects
{
    class ShakeMainCamera : MonoBehaviour
    {
        Camera _camera;

        [SerializeField] float _duration = 0.4f;
        [SerializeField] float _strength = 0.6f;
    
        void Awake() => _camera = Camera.main;

        public void Shake() => _camera.DOShakePosition(_duration, _strength);
    }
}