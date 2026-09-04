using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoonAttackController : MonoBehaviour
{
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        rb.velocity = new Vector2(0, 0);
    }
}
