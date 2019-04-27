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
        this.actualMenu = this.mainGO;
    }

    public void goToAbout()
    {
        this.actualMenu.SetActive(false);
        this.actualMenu = this.aboutGO;
        this.aboutGO.SetActive(true);
    }

    public void goToSettings()
    {
        this.actualMenu.SetActive(false);
        this.actualMenu = this.settingsGO;
        this.settingsGO.SetActive(true);
    }

    public void goToMain()
    {
        this.actualMenu.SetActive(false);
        this.actualMenu = this.mainGO;
        this.mainGO.SetActive(true);
    }

    public void goToHow()
    {
        this.actualMenu.SetActive(false);
        this.actualMenu = this.howGO;
        this.howGO.SetActive(true);
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
