using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;
    private float downTimer = 1.5f;
    private int score = 100;
    private int maxDifficultyScale = 4;
    private float elapsedTime;

    private void Start()
    {
        OnScoreChanged?.Invoke(score);
        StartCoroutine(ScoreDecay());
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    private IEnumerator ScoreDecay()
    {
        while(true)
        {
            float difficulty = 1f + elapsedTime / 110;
            difficulty = Mathf.Clamp(difficulty, 1f, maxDifficultyScale);
            float currentDecayTime = downTimer / difficulty;

            yield return new WaitForSeconds(currentDecayTime);
            score--;
            OnScoreChanged?.Invoke(score);
            if (score < 0)
            {
                GameOver();
                yield break;
            }
        }
    }

    private void OnEnable()
    {
        GameEvent.FoodEaten += OnFoodEaten;
    }

    private void OnDisable()
    {
        GameEvent.FoodEaten -= OnFoodEaten;
    }

    private void OnFoodEaten(FoodData foodData)
    {
        score += foodData.scoreValue;
        OnScoreChanged?.Invoke(score);
    }

    private void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
