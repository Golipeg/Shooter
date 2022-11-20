using System.Collections;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private float _hitEffectDuration=3f;
    public void ShowHitEffect(Vector3 hitPosition, Vector3 normal)
    {
        Instantiate(_hitEffect, hitPosition, Quaternion.LookRotation(normal));
        _hitEffect.Play();
        StartCoroutine(DestroyEffect(_hitEffect.gameObject,_hitEffectDuration));
    }

    private IEnumerator DestroyEffect(GameObject effect, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(effect);
    }
}