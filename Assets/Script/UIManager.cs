using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timeValue;
    [SerializeField] float scoreRemain = 60f;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject pauseScreen;
    int scoreValue;
    int scoreMultiple = 15;
    // Start is called before the first frame update
    void Start()
    {
        timeValue.text = scoreRemain.ToString("0.0");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreRemain();
    }
    public void AddScore(int score)
    {
        scoreValue += score * scoreMultiple;
        scoreText.text = scoreValue.ToString();
    }
    void ScoreRemain()
    {
        scoreRemain -= Time.deltaTime;
        timeValue.text = scoreRemain.ToString("0.0");
    }
    public void Pause ()
    {
        Time.timeScale = 0f;
        if (!pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(true);
        }
        FindObjectOfType<FruitManager>().canManage = false;
    }
    public void ReSume ()
    {
        Time.timeScale = 1f;
        if (pauseScreen.activeInHierarchy)
        {
            pauseScreen.SetActive(false);
        }
        FindObjectOfType<FruitManager>().canManage = true;
    }
}
