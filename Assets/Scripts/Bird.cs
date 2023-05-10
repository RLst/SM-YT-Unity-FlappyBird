using System;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public float flyForce = 5f;
    public bool isDead = false;

    [Header("Tilt")]
    public Vector2 velRange = new Vector2(-5, 5);
    public Vector2 tiltRange = new Vector2(-30, 15);

    //Events
    public UnityEvent onFlap;
    public UnityEvent onDeath;

    Rigidbody2D rb;

    void Start()
    {
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead)
            return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Flap();
        }

        HandleTilt();
    }

    void HandleTilt()
    {
        //Remap bird velocity to it's tilt level
        var tiltAngle = Utils.Remap(rb.velocity.y, velRange.x, velRange.y, tiltRange.x, tiltRange.y);

        //Convert from Euler angles to Quaternions
        Quaternion rotation = Quaternion.Euler(0, 0, tiltAngle);

        //Do the actual rotation
        transform.rotation = rotation;
    }

    void Flap()
    {
        rb.velocity = Vector2.up * flyForce;

        onFlap.Invoke();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>())
        {
            isDead = true;  //DEATH!

            onDeath.Invoke();
        }
    }
}
