using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button menuButton;
    public Button resumeButton;
    public Button quitToMenuButton;

    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (menuButton != null)
            menuButton.onClick.AddListener(TogglePauseMenu);

        if (resumeButton != null)
            resumeButton.onClick.AddListener(ResumeGame);

        if (quitToMenuButton != null)
            quitToMenuButton.onClick.AddListener(QuitToMainMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; 
        }
        else
        {
            Time.timeScale = 1f; 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }
}