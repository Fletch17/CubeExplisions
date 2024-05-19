using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Material[] _materials;
    [SerializeField] private Exploder _exploder;

    private int _minCount = 2;
    private int _maxCount = 6;
    private int _divisorForChance = 2;
    private int _spawnChance = 100;

    public void ReduceChance(int spawnChance)
    {
        _spawnChance = spawnChance / _divisorForChance;
    }

    public void Spawn()
    {
        int random = Random.Range(0, 101);

        if (_spawnChance >= random)
        {
            random = Random.Range(_minCount, _maxCount + 1);

            for (int i = 0; i < random; i++)
            {
                var cube = Instantiate(_cubePrefab, transform.position, transform.rotation);
                cube.transform.localScale = transform.localScale / 2;
                cube.GetComponent<MeshRenderer>().material = _materials[Random.Range(0, _materials.Length)];
                cube.GetComponent<CubeSpawn>().ReduceChance(_spawnChance);
            }
        }

        _exploder.Explode();
        Destroy(gameObject);
    }


}
