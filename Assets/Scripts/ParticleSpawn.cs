using UnityEngine;

class ParticleSpawn : MonoBehaviour
{
    ParticleSystem _particles;
    Transform _parent;
    Vector3 _offset;
    
    void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
        _parent = transform.parent;
        _offset = transform.position - _parent.position;
    }

    void OnParticleSystemStopped() => Parent(); 

    public void Play()
    {
        Parent();
        _particles.Play();
        UnParent();
    }

    void Parent()
    {
        transform.SetParent(_parent);
        transform.localPosition = _offset;
        transform.localScale = Vector3.one;
    }

    void UnParent()
    {
        transform.SetParent(null);
        transform.localScale = Vector3.one;
    }
}
