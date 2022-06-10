using DG.Tweening;
using UnityEngine;
using static DG.Tweening.Ease;

namespace MP.Effects
{
    class PopIn : MonoBehaviour
    {
        [SerializeField] float _duration = 0.8f;
        [SerializeField] Ease _ease = InOutQuart;
        
        void Start()
        {
            transform.localScale = new(0, 0, 1);
            transform.DOScale(Vector3.one, _duration).SetEase(_ease);
        }
    }
}
