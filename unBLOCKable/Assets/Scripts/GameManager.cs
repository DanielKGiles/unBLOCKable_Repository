using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public GameObject RestartButton;
    private int currentLevelIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        InitLevel();
    }

    //void Awake()
    //{
    //    DontDestroyOnLoad(player);
    //}

    public void InitLevel()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        //LoadLevel(currentLevelIndex);

        RestartButton.SetActive(true);

    }

    public static void RestartLevel()
    {
        LoadLevel(Instance.currentLevelIndex);
    }

    public static void LoadLevel(int levelIndexToLoad)
    {
        SceneManager.LoadScene(levelIndexToLoad);

    }

    private void OnRestart()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        //checkWinLose(); 
    }

    private void checkWinLose()
    {
        //Debug.Log(player.transform.position[0]);
        //Debug.Log(RestartButton.transform.position[0]);
        //if (player.transform.position[0] > 200) {

        //    RestartButton.SetActive(true);

        //}
    }
}
