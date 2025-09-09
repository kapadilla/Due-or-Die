using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject playerPrefab;
    private GameObject playerInstance;



    private void Start()
    {
        /*// Instantiate the player prefab at the desired position and rotation
        playerInstance = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        // If necessary, assign the player instance to other scripts (e.g., Boss script)
        Boss bossScript = FindObjectOfType<Boss>();
        if (bossScript != null)
        {
            bossScript.player = playerInstance.transform;
        }*/
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


