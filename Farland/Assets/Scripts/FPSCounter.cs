using UnityEngine.UI;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{

    public float timer, refresh, avgFramerate;
    string display = "{0} FPS";
    private Text m_Text;

    private void Start()
    {
        m_Text = GetComponent<Text>();
    }


    private void Update()
    {
        //Change smoothDeltaTime to deltaTime or fixedDeltaTime to see the difference
        float timelapse = Time.unscaledDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        m_Text.text = string.Format(display, avgFramerate.ToString());
    }
}