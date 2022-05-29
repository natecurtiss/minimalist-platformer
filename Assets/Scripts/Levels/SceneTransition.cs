using System;
using DG.Tweening;
using UnityEngine;
using static DG.Tweening.DOTween;
using static DG.Tweening.Ease;
using static UnityEngine.SceneManagement.SceneManager;

namespace MP.Levels
{
    class SceneTransition : MonoBehaviour
    {
        public static event Action OnStart;
        
        [SerializeField] float _in = 0.4f;
        [SerializeField] float _middleDelay = 0.4f;
        [SerializeField] float _out = 0.8f;
        [SerializeField] Ease _ease = Linear;
        
        SpriteRenderer _spriteRenderer;
        
        public static SceneTransition Main
        {
            get
            {
                if (_instance is null)
                {
                    var go = new GameObject("Scene Transition");
                    var sr = go.AddComponent<SpriteRenderer>();
                    sr.sortingOrder = 10;
                    sr.color = new(1, 1, 1, 0);
                    sr.sprite = Sprite.Create(Texture2D.whiteTexture, new(Vector2.zero, Vector2.one * 4), new(0.5f, 0.5f));
                    go.transform.localScale = new(3840, 2060, 1);
                    
                    _instance = go.AddComponent<SceneTransition>();
                    DontDestroyOnLoad(_instance);
                }
                return _instance;
            }
        }
        static SceneTransition _instance;

        void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

        public void Play(string toScene) => Sequence()
            .SetEase(_ease)
            .AppendCallback(() => OnStart?.Invoke())
            .Append(ToAlpha(() => _spriteRenderer.color, c => _spriteRenderer.color = c, 1f, _in))
            .AppendInterval(_middleDelay)
            .AppendCallback(() => LoadScene(toScene))
            .Append(ToAlpha(() => _spriteRenderer.color, c => _spriteRenderer.color = c, 0f, _out));
    }
}