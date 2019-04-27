using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainGO;
    [SerializeField] private GameObject howGO;
    [SerializeField] private GameObject aboutGO;
    [SerializeField] private GameObject settingsGO;

    private GameObject actualMenu;

    private void Start()
    {
        actualMenu = mainGO;
    }

    public void goToAbout()
    {
        actualMenu.SetActive(false);
        actualMenu = aboutGO;
        aboutGO.SetActive(true);
    }

    public void goToSettings()
    {
        actualMenu.SetActive(false);
        actualMenu = settingsGO;
        settingsGO.SetActive(true);
    }

    public void goToMain()
    {
        actualMenu.SetActive(false);
        actualMenu = mainGO;
        mainGO.SetActive(true);
    }

    public void goToHow()
    {
        actualMenu.SetActive(false);
        actualMenu = howGO;
        howGO.SetActive(true);
    }

    public void goToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
