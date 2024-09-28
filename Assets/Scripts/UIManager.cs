
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Desired frame rate
    public int targetFPS = 60;

    void Start()
    {
        // Set the target frame rate
        Application.targetFrameRate = targetFPS;

        // Optionally, set the fixed update frame rate (for physics calculations)
        QualitySettings.vSyncCount = 0; // Disable VSync to rely on targetFrameRate
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
