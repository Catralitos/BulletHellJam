using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool fullscreen;

    private void Awake()
    {
        if (fullscreen) Screen.SetResolution(1920, 1080, true, 60);
        else Screen.SetResolution(1280, 720, false, 60);
    }

    public void ToggleFullscreen()
    {
        if (fullscreen)
        {
            Screen.SetResolution(1280, 720, false, 60);
            fullscreen = false;
        }
        else
        {
            Screen.SetResolution(1920, 1080, true, 60);
            fullscreen = true;
        }
    }
}