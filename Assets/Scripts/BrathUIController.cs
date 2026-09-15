using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrathUIController : MonoBehaviour
{

    public TextMeshProUGUI breathUI;
    public float brathState;
    public PlayerBreathController pbc;
    
    void Update()
    {
        brathState = pbc.HPState;
        breathUI.text = "breathState : " + brathState.ToString();
    }
}
