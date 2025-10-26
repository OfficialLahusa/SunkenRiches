using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioSource source;

    public void Start()
    {
        source = GetComponent<AudioSource>();

        // Unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play()
    {
        //source.Play();
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
    }

    public void Quit()
    {
        //source.Play();
        Application.Quit();
    }
}
