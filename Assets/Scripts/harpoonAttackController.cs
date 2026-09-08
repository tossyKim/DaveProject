using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoonAttackController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject harpoon;
    public GameObject Attack_Start;
    public bool Attack_End;
    public float Attack_reach;
    public Vector2 recoveDir;
    public float backSpeed;

    private void Update()
    {
        recoveDir = Attack_Start.transform.position - harpoon.transform.position;
        if (Vector2.Distance(harpoon.transform.position, Attack_Start.transform.position) > Attack_reach)
        {
            rb.velocity = Vector2.zero;
            // n초 멈추기
            rb.velocity = recoveDir.normalized*backSpeed;
            if(recoveDir.magnitude < 1)
                harpoon.SetActive(false);
            Debug.Log("사거리 도달 회수 진행");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //물고기 공격
    {
        Debug.Log(collision.gameObject.tag);
        rb.velocity = Vector2.zero;
        //
        rb.velocity = recoveDir.normalized * backSpeed;
        if (recoveDir.magnitude < 1)
            harpoon.SetActive(false);
        Debug.Log("공격 완료 회수 진행");
    }
}
