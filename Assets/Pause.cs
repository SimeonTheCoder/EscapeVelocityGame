using FMODUnity;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;

    public GameObject pauseMenu;

    public GameObject[] otherMenus;

    public AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);

        for (int i = 0; i < otherMenus.Length; i++)
        {
            otherMenus[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Time.timeScale = paused ? 0 : 1;

            pauseMenu.SetActive(paused);

            if (!paused)
            {
                for (int i = 0; i < otherMenus.Length; i++)
                {
                    otherMenus[i].SetActive(false);
                }
            }

            Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;

            if (paused) audioManager.PauseAll();
            else audioManager.Unpause();
        }
    }
}
