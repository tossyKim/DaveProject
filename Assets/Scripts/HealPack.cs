using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : MonoBehaviour
{
    public GameObject SpaceBarIcon;
    public float inputTime;
    public float fullTime;

    private void Update()
    {
        inputTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SpaceBarIcon.SetActive(true);
            if (inputTime >= fullTime)
            {
                // Breath += ??
            }
        }
    }
}
