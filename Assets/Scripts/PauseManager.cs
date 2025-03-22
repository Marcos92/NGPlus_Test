using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    void Awake()
    {
        PlayerGameplayInput.OnMenuDown.AddListener(TogglePause);
    }

    private void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
}