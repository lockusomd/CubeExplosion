using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    private int _explosionForce = 400;
    private int _explosionRadius = 360;

    public void Explode(List<Rigidbody> rigidbodies)
    {
        foreach(Rigidbody rigidbody in rigidbodies)
            rigidbody.AddExplosionForce(_explosionForce, rigidbody.transform.position, _explosionRadius);
    }
}
