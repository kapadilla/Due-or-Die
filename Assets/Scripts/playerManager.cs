using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class playerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject gameOverUI;
    public static Vector2 origin = new Vector2(-3, 0);
    public GameObject[] playerPrefabs;
    int characterIndex;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], origin, Quaternion.identity);
        isGameOver = false;

    }

    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void ReplayLevel()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
