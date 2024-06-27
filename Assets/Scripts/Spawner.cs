using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    private int _minCubes = 2;
    private int _maxCubes = 6;
    private int _scaleDivisor = 2;

    public List<Rigidbody> CreateCubes(Rigidbody rigidbody)
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        rigidbody.transform.localScale /= _scaleDivisor;

        for (int i = 0; i < Random.Range(_minCubes, _maxCubes); i++)
        {
            rigidbodies.Add(Object.Instantiate(rigidbody, rigidbody.transform.parent));
        }

        return rigidbodies;
    }
}