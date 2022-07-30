using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void StartButtonOnClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SettingsButtonOnClick()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }
}
