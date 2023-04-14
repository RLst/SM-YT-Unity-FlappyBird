using UnityEngine;

public class Despawner : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Obstacle>())
        {
            Destroy(other.gameObject);
        }
    }
}
