using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Scenes/PrimerNivel");
        MenuManager.Instance.ClearScene();
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
