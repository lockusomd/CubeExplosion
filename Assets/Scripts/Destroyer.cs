using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private int _spawnChance = 100;

    public int SpawnChance => _spawnChance;

    public void DestroyPrefab()
    {
        if(Random.Range(1,100) < _spawnChance)
        GetComponent<Spawner>().CreateCubes();

        Destroy(this.gameObject);
    }

    public void SetSpawnChance(int spawnChance)
    {
        _spawnChance = spawnChance;
    }
}
