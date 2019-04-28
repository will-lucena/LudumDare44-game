using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainGO;
    [SerializeField] private GameObject howGO;
    [SerializeField] private GameObject aboutGO;
    [SerializeField] private GameObject settingsGO;

    private GameObject actualMenu;
    private GameObject lastMenu;

    private void OnEnable()
    {
        if (lastMenu == gameObject)
        {
            Debug.Log(lastMenu);
        }
    }

    private void Start()
    {
        actualMenu = mainGO;
        SlideAnimationController.notifySlideEnd += startSlideIn;
    }

    public void goToAbout()
    {
        lastMenu = actualMenu;
        actualMenu.GetComponent<Animator>().SetTrigger("slide out");
        actualMenu = aboutGO;
    }

    public void goToSettings()
    {
        lastMenu = actualMenu;
        actualMenu.GetComponent<Animator>().SetTrigger("slide out");
        actualMenu = settingsGO;
    }

    public void goToMain()
    {
        lastMenu = actualMenu;
        actualMenu.GetComponent<Animator>().SetTrigger("slide out");
        actualMenu = mainGO;
    }

    public void goToHow()
    {
        lastMenu = actualMenu;
        actualMenu.GetComponent<Animator>().SetTrigger("slide out");
        actualMenu = howGO;
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

    private void startSlideIn(GameObject obj)
    {
        if (obj == lastMenu)
        {
            actualMenu.GetComponent<Animator>().SetTrigger("slide in");
        }        
    }
}
