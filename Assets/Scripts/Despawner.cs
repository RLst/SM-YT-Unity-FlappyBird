using UnityEngine;

public class Despawner : MonoBehaviour
{
    //Detects if another collider has entered into our trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}

