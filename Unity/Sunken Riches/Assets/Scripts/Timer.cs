using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TMP_Text text;

    // Set timer to 3 min
    public float remainingSeconds = 3 * 60.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Advance timer
        remainingSeconds -= Time.deltaTime;

        if (remainingSeconds < 0)
        {
            remainingSeconds = 0;
        }

        int minutes = Mathf.FloorToInt(remainingSeconds / 60f);
        int seconds = Mathf.FloorToInt(Mathf.Repeat(remainingSeconds, 60f));

        text.SetText($"{minutes}:{seconds:D2}");
    }
}
