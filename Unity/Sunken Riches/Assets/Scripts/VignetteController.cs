using UnityEngine;
using UnityEngine.UI;

public class VignetteController : MonoBehaviour
{
    public Timer timer;
    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        float alpha = 0f;
        float hpPercent = timer.remainingSeconds / Timer.TIMER_LENGTH;
        float thresh = 0.12f;

        if (hpPercent <= thresh)
        {
            // Scale alpha from 0 to 1 as health goes from 50% to 0%
            alpha = EaseOut(1f - (hpPercent * (1f / thresh)), 2);
        }

        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
    }

    private float EaseOut(float value, float pow)
    {
        return 1 - Mathf.Pow(1 - value, pow);
    }
}
