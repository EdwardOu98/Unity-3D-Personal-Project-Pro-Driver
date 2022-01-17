using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{

    [SerializeField] private Button startButton;
    [SerializeField] private Button highScoreButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private InputField usernameEntry;

    
    public void StartButtonClicked()
    {
        GameManager.Instance.username = usernameEntry.text;
        SceneManager.LoadScene(1);
    }

    public void HighScoreButtonClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
