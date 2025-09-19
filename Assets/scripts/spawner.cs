using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnrate;
    public float maxrange;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnrate, spawnrate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject lands = Instantiate(prefab, transform.position, Quaternion.identity);
        lands.transform.position += Vector3.right * Random.Range(maxrange, -maxrange);
    }
}
