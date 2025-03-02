using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public RawImage blackScreen;

    private float progress;
    private float speed;

    private bool ticking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.speed = 1f;
        this.progress = 1f;

        Color c = blackScreen.color;
        c.a = 1f;

        blackScreen.color = c;

        FadeOut(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.ticking) return;

        this.progress += Time.deltaTime * speed;

        this.progress = Mathf.Max(0f, Mathf.Min(1f, this.progress));

        Color c = blackScreen.color;
        c.a = this.progress;

        blackScreen.color = c;
    }

    public void FadeOut(float speed)
    {
        this.speed = -speed;
        ticking = true;
    }

    public void FadeIn(float speed)
    {
        this.speed = speed;
        ticking = true;
    }
}
