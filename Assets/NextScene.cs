using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Fade blackScreen;

    public float delay;

    private float time;
    private bool isTicking = false;

    public int sceneIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTicking) time += Time.unscaledDeltaTime;

        if (time > delay)
        {
            SceneManager.LoadScene(
                this.sceneIndex
            );
        }        
    }

    public void Click(int scene)
    {
        Time.timeScale = 1f;

        this.sceneIndex = scene;

        if (this.sceneIndex == -1)
        {
            this.sceneIndex = PlayerPrefs.GetInt("STAGE");
        }
        else if (this.sceneIndex == -2)
        {
            Application.Quit();
        }

        Debug.Log("LOADING INTO: " + this.sceneIndex);

        isTicking = true;

        blackScreen.FadeIn(this.delay);
    }
}
