using UnityEngine;

public class MouseClicker : MonoBehaviour
{
    private CubeSpawn _cubeSpawn;

    private void Awake()
    {
        _cubeSpawn = GetComponent<CubeSpawn>();
    }

    private void OnMouseDown()
    {
        _cubeSpawn.Spawn();
    }
}
