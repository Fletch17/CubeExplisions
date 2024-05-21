using UnityEngine;

public class RandomUtils
{
    public static Vector3 GetRandomVector3(Vector3 minValues, Vector3 maxValues)
    {
        return new Vector3(Random.Range(minValues.x, maxValues.x), Random.Range(minValues.y, maxValues.y), Random.Range(minValues.z, maxValues.z));
    }
}
