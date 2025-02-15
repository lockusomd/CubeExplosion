using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _spawnChance = 100;
    [SerializeField] private int _probabilityDivisor = 2;

    private Spawner _spawner = new Spawner();
    private Exploder _exploder = new Exploder();

    private int _minPercent = 1;
    private int _maxPercent = 100;

    public int SpawnChance => _spawnChance;

    public void DestroyObject()
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        if (Random.Range(_minPercent, _maxPercent) < _spawnChance)
        {
            rigidbodies = _spawner.CreateCubes(GetComponent<Rigidbody>());

            SetColor(rigidbodies);

            SetSpawnChance(rigidbodies);

            _exploder.Explode(rigidbodies, transform.position);
        }
        else
        {
            GetComponent<SphereCollider>().enabled = true;

            foreach (Collider collider in Physics.OverlapSphere(transform.position, 5))
            {
                if(collider.TryGetComponent<Cube>(out Cube component))
                {
                    rigidbodies.Add(component.GetComponent<Rigidbody>());
                }
            }

            _exploder.Explode(rigidbodies, transform.position, transform.localScale.x);
        }

        Destroy(gameObject);
    }

    public void SetSpawnChance(int spawnChance)
    {
        _spawnChance = spawnChance;
    }

    private void SetSpawnChance(List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
            rigidbody.GetComponent<Cube>().SetSpawnChance(GetComponent<Cube>().SpawnChance / _probabilityDivisor);
    }

    private void SetColor(List<Rigidbody> rigidbodies)
    {
        foreach(Rigidbody rigidbody in rigidbodies)
            rigidbody.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
