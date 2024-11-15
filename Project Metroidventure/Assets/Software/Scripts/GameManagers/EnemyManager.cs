using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject ScoreText;
    float sayac;
    private int score = 0;

    void Start()
    {
        ScoreText.GetComponent<Text>().text = "Score : " + score;
    }

    void Update()
    {
        sayac -= Time.deltaTime;

        if(sayac < 0)
        {
            Vector3 SpawnTransform = new Vector3(Random.Range(12, -12), Random.Range(7, -7), 0);
            Instantiate(enemyPrefab, SpawnTransform, Quaternion.identity, null);
            sayac = 2;
        }
    }

    public void SkorArttiranAnimeKizlari()
    {
        score++;
        ScoreText.GetComponent<Text>().text = "Score : " + score;
    }
}
