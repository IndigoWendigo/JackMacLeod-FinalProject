using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited Successfully.");
    }

    public string sceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }


}
