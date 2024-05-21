using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private List<Material> _materials;
    [SerializeField] private Exploder _exploder;

    private int _minCount = 2;
    private int _maxCount = 6;
    private int _divisorForChance = 2;
    private int _divisorForScale = 2;

    public void Spawn()
    {
        int minPercent = 0;
        int maxPercent = 100;
        int random = Random.Range(minPercent, maxPercent);
        List<Rigidbody> cubes = new List<Rigidbody>();

        if (_prefab.SpawnChance >= random)
        {
            random = Random.Range(_minCount, _maxCount + 1);

            for (int i = 0; i < random; i++)
            {
                Vector3 distanceFromCenter = transform.localScale / 2f;
                Vector3 deltaPosition = RandomUtils.GetRandomVector3(-distanceFromCenter, distanceFromCenter);
                Vector3 position = transform.position + deltaPosition;
                Vector3 newScale = transform.localScale / _divisorForScale;
                int newChance = _prefab.SpawnChance / _divisorForChance;

                var cube = Instantiate(_prefab, position, Quaternion.identity);
                cube.Init(newScale, newChance);

                if (cube.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                {
                    cubes.Add(rigidbody);
                }
            }

            _exploder.Explode(cubes);
        }

        Destroy(gameObject);
    }
}
