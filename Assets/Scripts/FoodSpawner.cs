using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private FoodData[] foodDatas;
    private float elipsedTime;
    private float difficulty = 1;

    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 5f;

    [SerializeField] private float spawnY = 5.8f;
    [SerializeField] private float minX = -0.2f;
    [SerializeField] private float maxX = 1.2f;

    [SerializeField] private float overlapRadius = 0.6f;
    [SerializeField] private LayerMask foodLayer;
    [SerializeField] private int checkForAttempts = 5;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private void Update()
    {
        elipsedTime += Time.deltaTime;
        difficulty = 1 + elipsedTime / 50;
        difficulty = Mathf.Clamp(difficulty, 0.02f, 8f);
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float currentMin = minSpawnTime / difficulty;
            float currentMax = maxSpawnTime / difficulty;

            currentMin = Mathf.Max(0.01f, currentMin);
            currentMax = Mathf.Max(currentMin + 0.01f, currentMax);

            float waitTime = Random.Range(currentMin, currentMax);

            yield return new WaitForSeconds(waitTime);
            SpawnFood();
        }
    }


    private void SpawnFood()
    {
        for (int i = 0; i < checkForAttempts; i++)
        {
            float spawnWidth = Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(spawnWidth, spawnY);

            if(IsPositionFree(spawnPosition))
            {
                GameObject spawnedFood = Instantiate(food, new Vector3(spawnWidth, spawnY, 0), transform.rotation);

                Food foodComponent = spawnedFood.GetComponent<Food>();
                FoodData randomFoodData = foodDatas[RandomListElement()];
                foodComponent.SetData(randomFoodData);

                return;
            }
        }
    }    

    private bool IsPositionFree(Vector2 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, overlapRadius, foodLayer);

        return hit == null;
    }

    private int RandomListElement()
    {
        return Random.Range(0, foodDatas.Length);
    }

}
