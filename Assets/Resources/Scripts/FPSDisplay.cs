using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
  //  public Text textPanel;

    public int monsters=0;

    float deltaTime = 0.0f;

    bool active;

    void Update()
    {
        StartStop();

        if (active)
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void StartStop()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (active)
            {
                active = false;
            }
            else
            {
                active = true;
            }
        }
    }

    void OnGUI()
    {
        if (active)
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(10, 70, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            // string text = string.Format("{0:0.0} ms ({1:0.} fps )", msec, fps);
            // GUI.Label(rect, text, style);

            string text = string.Format("{0:0.0} ms ({1:0.} fps ) ({2:0.} monsters)", msec, fps, monsters);
            GUI.Label(rect, text, style);
        }
    }
}