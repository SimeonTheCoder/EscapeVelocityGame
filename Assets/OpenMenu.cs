using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject menu;
    private bool active;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menu.SetActive(false);
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        active = !active;
        menu.SetActive(active);
    }
}
