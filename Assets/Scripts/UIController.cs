using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI TimerUI;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;        
        TimerUI.text = timer.ToString();
    }
}
