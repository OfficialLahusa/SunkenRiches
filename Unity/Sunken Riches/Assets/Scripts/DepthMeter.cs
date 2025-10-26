using TMPro;
using UnityEngine;

public class DepthMeter : MonoBehaviour
{
    public Transform player;
    TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float depth = player.position.y-100;

        text.SetText(((int)depth).ToString()+"m");
    }
}
