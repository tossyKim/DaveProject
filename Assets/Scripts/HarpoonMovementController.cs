using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonMovementController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float power;
    public Rigidbody2D rb_Player;
    public GameObject Player;

    public void Shoot(Vector2 attackDir)
    {
        Debug.Log("Shoot »£√‚µ ");
        rb.velocity = attackDir * power;
        rb_Player.velocity = new Vector2(0, 0);
    }
        
}
