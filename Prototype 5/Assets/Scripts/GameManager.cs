using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreem;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score;
    public TextMeshProUGUI scoreText;

    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public bool isGameActive;
    // Start is called before the first frame update
   void Start()
    {
  
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }

    }

    public void UpdateScore(int ScoreToAdd)
    {
        if(isGameActive)
        {
            score += ScoreToAdd;
            scoreText.text = "Score: " + score;
        }
  
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int diffuculty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= diffuculty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreem.gameObject.SetActive(false);

    }
}
