using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    private GameObject player;
    private AudioManager audioManager;

    [SerializeField] private Text scoreText;
    private Text tapToPlayText;
    private float currentTime;

    [SerializeField] private float delayTime = 2f;
    [SerializeField] private GameObject downBoundaries;

    [SerializeField] private bool isMenuLevel = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        tapToPlayText = FindObjectOfType<Text>().GetComponent<Text>();
    }

    private void Start()
    {
        Time.timeScale = 0;
        audioManager.OnStartGame();
        score = 0;
    }
    private void Update()
    {
        OnTouchStart();
    }

    public void Play()
    {
        player.SetActive(true);
        score = 0;
        scoreText.text = score.ToString();
        Time.timeScale = 1f;
    }

    public void DelayGameOver()
    {
        if (downBoundaries) downBoundaries.SetActive(false);
        audioManager.OnGameOver();
        Invoke("GameOver", 3f);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void IncreaseScore()
    {
        audioManager.OnPointEarned();
        score++;
        scoreText.text = score.ToString();
    }

    private void OnTouchStart()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            if (tapToPlayText) tapToPlayText.enabled = false;
            Time.timeScale = 1f;
        }
    }
}

