using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public float zVelocity;
    public float timeToDestroy;
    private void Update()
    {
        transform.Translate(0, 0, zVelocity * Time.deltaTime);
        Invoke("DestroyItem", timeToDestroy);
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}