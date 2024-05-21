using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private int _spawnChance = 100;

    public int SpawnChance => _spawnChance;

    public void Init(Vector3 scale, int spawnChance)
    {
        transform.localScale = scale;
        _spawnChance = spawnChance;
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }
}
