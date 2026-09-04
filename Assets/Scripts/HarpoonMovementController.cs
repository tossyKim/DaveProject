using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonMovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float power;

    public void Shoot(Vector2 attackDir)
    {
        rb.velocity = attackDir * power;
    }
        
}
