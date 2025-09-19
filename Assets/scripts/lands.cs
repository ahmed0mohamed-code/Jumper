using UnityEngine;

public class lands : MonoBehaviour
{
    public float speed = 5f;

    private float downedge;


    private void Start()
    {
        downedge = Camera.main.ScreenToWorldPoint(Vector3.zero).y - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if(transform.position.y < downedge)
        {
            Destroy(gameObject);
        }
    }
}
