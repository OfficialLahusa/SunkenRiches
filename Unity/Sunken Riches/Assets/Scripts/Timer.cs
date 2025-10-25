using Rive;
using Rive.Components;
using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public RiveWidget timerWidget;

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

            /*// Get reference by name
            ViewModel viewModel = file.GetViewModelByName("My View Model");

            // Get reference by index
            for (int i = 0; i < file.ViewModelCount; i++)
            {
                ViewModel indexedVM = file.GetViewModelAtIndex(i);
            }*/

            // Get reference to the default view model for an artboard
            ViewModel defaultVM = timerWidget.Artboard.DefaultViewModel;
            //ViewModel defaultVM = timerWidget.File.

            ViewModelInstance defaultVMI = defaultVM.CreateDefaultInstance();

            timerWidget.StateMachine.BindViewModelInstance(defaultVMI);

            // A list of properties
            var properties = defaultVM.Properties;
            foreach (var prop in properties)
            {
                Debug.Log($"Property: {prop.Name}, Type: {prop.Type}");
            }

            foreach(SMIInput input in timerWidget.StateMachine.Inputs())
            {
                Debug.Log(input.Name);
                Debug.Log(input.IsNumber);
            }
        }
    }
}
