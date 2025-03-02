using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Fade blackScreen;

    public float delay;

    private float time;
    private bool isTicking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTicking) time += Time.deltaTime;

        if (time > delay)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1
            );
        }        
    }

    public void Click()
    {
        isTicking = true;

        blackScreen.FadeIn(this.delay);
    }
}
