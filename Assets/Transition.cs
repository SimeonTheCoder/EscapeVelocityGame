using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public KeyHolder player;

    public Fade blackScreen;

    private bool inside = false;
    public int offset;

    public float delay;

    public string key;

    public bool isAutomatic;

    public StudioEventEmitter door;
    public StudioEventEmitter noKeySound;

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
                SceneManager.GetActiveScene().buildIndex + offset
            );
        }

        if (!inside) return;

        if (Input.GetKeyDown("e") || isAutomatic)
        {
            if (key != "" && !player.CheckKey(key))
            {
                noKeySound.Play();
                return;
            }

            isTicking = true;

            blackScreen.FadeIn(this.delay);

            if(!isAutomatic) door.Play();
        }
    }

    void OnTriggerEnter()
    {
        inside = true;
    }

    void OnTriggerExit()
    {
        inside = false;
    }
}
