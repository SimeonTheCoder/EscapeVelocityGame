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

    private bool hadKeyPrevFrame = false;

    public Material doorMat;
    public Material exitMat;

    public GameObject lockQuad;

    public ExitDoor exitDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0f;

        doorMat.SetColor("_EmissiveColor", Color.black * 300000);
        exitMat.SetColor("_EmissiveColor", Color.black * 300000);
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

        if (key != "")
        {
            if (player.CheckKey(key))
            {
                if (!hadKeyPrevFrame) lockQuad.SetActive(false);

                doorMat.SetColor("_EmissiveColor", Color.green * 300000);
                exitMat.SetColor("_EmissiveColor", Color.green * 300000);

                hadKeyPrevFrame = true;
            }
            else
            {
                doorMat.SetColor("_EmissiveColor", Color.black * 300000);
                exitMat.SetColor("_EmissiveColor", Color.black * 300000);

                hadKeyPrevFrame = false;
            }
        }

        if (!inside) return;

        if (/*Input.GetKeyDown("e") || isAutomatic*/ true)
        {
            if (key != "" && !player.CheckKey(key))
            {
                noKeySound.Play();
                return;
            }

            isTicking = true;

            blackScreen.FadeIn(this.delay);

            if(!isAutomatic) door.Play();

            if (!isAutomatic) exitDoor.Trigger();
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
