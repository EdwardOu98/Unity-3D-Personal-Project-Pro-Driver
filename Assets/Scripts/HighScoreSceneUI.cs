using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreSceneUI : MonoBehaviour
{
    [SerializeField] Text playerNameText;
    [SerializeField] Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = GameManager.Instance.recordKeeper;
        highScoreText.text = GameManager.Instance.highScore.ToString();
    }

    public void ReturnButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
