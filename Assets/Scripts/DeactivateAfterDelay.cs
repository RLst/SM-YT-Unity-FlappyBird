using UnityEngine;

public class DeactivateAfterDelay : MonoBehaviour
{
    public float deactivationDelay = 5f;
    float time = 0f;

    void Update()
    {
        time += Time.deltaTime;

        if (time > deactivationDelay)
            gameObject.SetActive(false);
    }
}
