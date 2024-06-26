using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;
    [SerializeField] private int _scaleDivisor = 2;
    [SerializeField] private int _explosionForce = 400;
    [SerializeField] private int _explosionRadius = 360;
    [SerializeField] private int _probabilityDivisor = 2;

    public void CreateCubes()
    {
        transform.localScale = transform.localScale / _scaleDivisor;

        for (int i = 0; i < Random.Range(_minCubes, _maxCubes); i++)
        {
            GameObject prefab = Instantiate(gameObject, transform.parent);

            prefab.GetComponent<Destroyer>().SetSpawnChance(GetComponent<Destroyer>().SpawnChance / _probabilityDivisor);

            prefab.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

            prefab.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}