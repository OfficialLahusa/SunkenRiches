using Rive;
using Rive.Components;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public RiveWidget timerWidget;

    TMP_Text text;

    // Set timer to 3 min
    public const float TIMER_LENGTH = 3 * 60.0f; 
    public float remainingSeconds = TIMER_LENGTH;

    private ViewModelInstanceNumberProperty _progress;

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

            SceneManager.LoadScene("End", LoadSceneMode.Single);
        }

        int minutes = Mathf.FloorToInt(remainingSeconds / 60f);
        int seconds = Mathf.FloorToInt(Mathf.Repeat(remainingSeconds, 60f));

        text.SetText($"{minutes}:{seconds:D2}");

        if (_progress != null)
        {
            _progress.Value = 100 * remainingSeconds / TIMER_LENGTH;
        }
    }

    private void OnEnable()
    {
        timerWidget.OnWidgetStatusChanged += HandleWidgetStatusChanged;
    }

    private void OnDisable()
    {
        timerWidget.OnWidgetStatusChanged -= HandleWidgetStatusChanged;
    }

    private void HandleWidgetStatusChanged()
    {
        if (timerWidget.Status == WidgetStatus.Loaded)
        {
            File file = timerWidget.File;
            ViewModel viewModel = file.GetViewModelByName("O2 Model");
            ViewModelInstance viewModelInstance = viewModel.CreateInstanceByName("Instance");

            timerWidget.StateMachine.BindViewModelInstance(viewModelInstance);

            _progress = viewModelInstance.GetNumberProperty("O2 Value");
        }
    }
}
