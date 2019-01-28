using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.1f, 10f)] [SerializeField] float gamespeed = 1f;
    [SerializeField] int pointsPerblockdestroyed = 83;
    [SerializeField] int currentscore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool IsAutoPlayEnabled;

    // Update is called once per frame

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentscore.ToString();
    }
    void Update()
    {
        Time.timeScale = gamespeed;

    }

    public void AddtoScore()
    {
        currentscore = currentscore + pointsPerblockdestroyed;
        scoreText.text = currentscore.ToString();
    }

    public void resetgame()
    {
        Destroy(gameObject);
    }

} 
 