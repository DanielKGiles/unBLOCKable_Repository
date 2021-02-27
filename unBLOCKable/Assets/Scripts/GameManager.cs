using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public ParticleSystem CollisionParticleEffect;

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

    public void RestartLevel()
    {
        //DisplayCollisionParticleEffect();
        //DestroyGameObject(this.player);
        LoadLevel(Instance.currentLevelIndex);
    }

    public void LoadLevel(int levelIndexToLoad)
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

    private static void checkWinLose()
    {
        //Debug.Log(player.transform.position[0]);
        //Debug.Log(RestartButton.transform.position[0]);
        //if (player.transform.position[0] > 200) {

        //    RestartButton.SetActive(true);

        //}
    }

    public void DisplayCollisionParticleEffect(Transform playerPosition, GameObject player)
    {
        Debug.Log("Object is about to be instantiated");
        Vector3 particleEffectOffset = new Vector3(-1.00f, 0.00f, 0.00f);
        Instantiate(CollisionParticleEffect, playerPosition.position, Quaternion.identity);
        Debug.Log("Object was instantiated");
        DestroyGameObject(player);
    }

    private static void DestroyGameObject(GameObject gameObject)
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }

    }

   
}
