using UnityEngine;
using static UnityEngine.Mathf;

namespace MP.Effects
{
    class SineMovement : MonoBehaviour
    {
        [SerializeField] float _speed = 1f;
        [SerializeField] float _distance = 1f;
        float _offset;

        void Awake() => _offset = transform.position.y;

        void Update()
        {
            var y = Sin(Time.time * _speed) * _distance + _offset;
            transform.position = new(transform.position.x, y, transform.position.z);
        }
    }
}
