using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

    public void Explode(List<Rigidbody> explodableObjects)
    {
        foreach (Rigidbody explodableObject in explodableObjects)
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    public void Explode()
    {
        foreach (var explodableObject in GetExplodableObjects())
        {
            if (explodableObject.Value != 0)
            {
                float newForce = _explosionForce / explodableObject.Value;
                explodableObject.Key.AddExplosionForce(newForce, transform.position, _explosionRadius);
            }
        }
    }

    public void ChangeExplodeParameters(float explosionRadius, float explosionForce)
    {
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;
    }

    private Dictionary<Rigidbody,float> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        Dictionary<Rigidbody, float> cubes = new Dictionary<Rigidbody, float>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                var heading = hit.transform.position - transform.position;
                var distance = heading.magnitude;
                
                cubes.Add(hit.attachedRigidbody, distance);
            }
        }

        return cubes;
    }
}
