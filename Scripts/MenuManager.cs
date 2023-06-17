using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int gameStartScene;
    public int Ingamescene;
    public GameObject HelpPanel;
    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(Ingamescene);
    }

    public void HelpOpen()
    {
        HelpPanel.SetActive(true);
    }
    
    public void HelpClose()
    {
        HelpPanel.SetActive(false);
    }
}
 