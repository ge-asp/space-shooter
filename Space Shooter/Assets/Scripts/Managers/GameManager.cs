using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool shouldQuitGame => Input.GetKeyUp(KeyCode.Escape);

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;   
    }

    void Update()
    {
        if (shouldQuitGame)
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
