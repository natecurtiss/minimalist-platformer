using DG.Tweening;
using UnityEngine;
using static UnityEngine.Mathf;

namespace Effects
{
    class FlipDirection : MonoBehaviour
    {
        [SerializeField] float _duration = 0.1f;

        public void Change(int direction)
        {
            if (!ShouldFlip(direction))
                return;
            var flip = -Sign(transform.localScale.x);
            transform.DOScaleX(flip, _duration);
        }

        bool ShouldFlip(int direction) => direction != Sign(transform.localScale.x);
    }
}