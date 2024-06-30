using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    private int _explosionForce = 400;
    private int _explosionRadius = 360;

    public void Explode(List<Rigidbody> rigidbodies, Vector3 position, float size = 1)
    {
        Debug.Log(size);

        float basicSize = 1;
        float factor = basicSize / size;

        foreach (Rigidbody rigidbody in rigidbodies)
            rigidbody.AddExplosionForce(_explosionForce * factor, position, _explosionRadius * factor);
    }
}
