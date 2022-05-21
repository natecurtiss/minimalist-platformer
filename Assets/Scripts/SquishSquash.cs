using DG.Tweening;
using UnityEngine;
using static DG.Tweening.DOTween;

class SquishSquash : MonoBehaviour
{
    [SerializeField] float _duration = 0.3f;

    [Header("In")]
    [SerializeField] float _inX = 1f;
    [SerializeField] float _inY = 1f;
    
    [Header("Out")]
    [SerializeField] float _outX = 1f;
    [SerializeField] float _outY = 1f;

    Sequence _sequence;
    
    public void Do()
    {
        var initial = transform.localScale;
        var inScale = new Vector3(_inX, _inY, 1f);
        var outScale = new Vector3(_outX, _outY, 1f);
        _sequence?.Kill();
        _sequence = Sequence()
            .Append(transform.DOScale(inScale, _duration))
            .Append(transform.DOScale(outScale, _duration))
            .Append(transform.DOScale(initial, _duration));
    }
}
