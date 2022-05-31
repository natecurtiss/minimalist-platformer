using DG.Tweening;
using UnityEngine;
using static DG.Tweening.DOTween;
using static DG.Tweening.Ease;

namespace MP.Effects
{
    class FadeAway : MonoBehaviour
    {
        SpriteRenderer _spriteRenderer;

        [SerializeField] float _duration = 0.5f;
        [SerializeField] Ease _ease = Linear;
        
        void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

        public void Do() => ToAlpha(() => _spriteRenderer.color, c => _spriteRenderer.color = c, 0f, _duration).SetEase(_ease).Play();
    }
}
