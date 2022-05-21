using DG.Tweening;
using UnityEngine;
using static DG.Tweening.DOTween;

class SquashAndStretch : MonoBehaviour
{
    [SerializeField] float _recoverDuration = 0.3f;
    [SerializeField] Ease _ease;
    
    [Header("In")]
    [SerializeField] float _inX = 1f;
    [SerializeField] float _inY = 1f;
    [SerializeField] float _inDuration = 0.3f;

    [Header("Out")]
    [SerializeField] float _outX = 1f;
    [SerializeField] float _outY = 1f;
    [SerializeField] float _outDuration = 0.3f;

    Vector3 _initial;

    void Awake() => _initial = transform.localScale;

    public void Do()
    {
        var inScale = new Vector3(_inX, _inY, 1f);
        var outScale = new Vector3(_outX, _outY, 1f);
        Sequence()
            .Append(transform.DOScale(inScale, _inDuration))
            .Append(transform.DOScale(outScale, _outDuration))
            .Append(transform.DOScale(_initial, _recoverDuration))
            .SetEase(_ease).Play();
    }
}
