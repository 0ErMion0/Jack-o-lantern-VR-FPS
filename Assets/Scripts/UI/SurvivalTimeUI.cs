using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTimeUI : MonoBehaviour
{
    float startTime;
    TextMeshProUGUI textUI;
    
    // Start is called before the first frame update
    void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        textUI.text = $"Survival Time\n{Time.time - startTime:0.0}s";
    }
}
