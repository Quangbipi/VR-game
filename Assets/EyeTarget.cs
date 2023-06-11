using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTarget : MonoBehaviour
{
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();   
    }

    // Update is called once per frame
    // draw the reticle +
    void OnGUI()
    {
        int size = 42;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.normal.textColor = Color.red;
        GUI.Label(new Rect(posX, posY, size, size), "+", style);
    }
}
