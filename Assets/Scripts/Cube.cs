using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Exploder))]
public class Cube : MonoBehaviour
{
    private int _spawnChance = 100;

    public int SpawnChance => _spawnChance;

    public void Init(Vector3 scale, int spawnChance)
    {
        transform.localScale = scale;
        _spawnChance = spawnChance;
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }
}
