using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Dictionary<string, int> players;
    Dictionary<int, int> matchingLayers;
    static public SceneController instance;
    private bool gameOver = false;

    void Awake()
    {
        if (instance != null)
            return;
        instance = this;
        players = new Dictionary<string, int>();
        matchingLayers = new Dictionary<int, int>();
        matchingLayers[LayerMask.NameToLayer("Blue")] = LayerMask.NameToLayer("BluePlayer");
        matchingLayers[LayerMask.NameToLayer("Yellow")] = LayerMask.NameToLayer("YellowPlayer");
        matchingLayers[LayerMask.NameToLayer("Red")] = LayerMask.NameToLayer("RedPlayer");
        foreach (int key in matchingLayers.Keys)
        {
            Debug.Log(key);
            Debug.Log(matchingLayers[key]);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log(SceneManager.GetActiveScene().name + " reset!");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextScene();
        }
    }

    public void AddPlayer(string player)
    {
        players[player] = 0;
    }

    public int GetMatchingLayer(int layer)
    {
        return matchingLayers[layer];
    }

    public int GetKeyFromValue(int layer)
    {
        foreach ((int key, int value) in matchingLayers)
        {
            if (value == layer)
                return key;
        }
        return 0;
    }

    public void LoadNextScene()
    {
        gameOver = false;
        Scene currentScene = SceneManager.GetActiveScene();

        Debug.Log(currentScene.name + " completed!");
        foreach (PlayerController player in FindObjectsOfType<PlayerController>())
            player.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        if (currentScene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
            Debug.Log("Onto next stage!\n" + SceneManager.GetActiveScene().name + " started!");
        }
        else
        {
            Debug.Log("Victory!");
            Application.Quit();
        }
    }

    public void PlayerAtExit(string player, int status)
    {
        players[player] = status;
        int count = 0;
        foreach ((string name, int state) in players)
        {
            if (state == 1)
                count++;
        }
        if (count == players.Count)
            LoadNextScene();
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            foreach(PlayerController player in FindObjectsOfType<PlayerController>())
            {
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation + 10;
                player.enabled = false;
            }
            Debug.Log("Game Over!\nPress R to reload.");
        }
    }
}
