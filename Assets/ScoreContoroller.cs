using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContoroller : MonoBehaviour
{

    public Text scoreText; //Text用変数
    private int score = 0; //スコア計算用変数

    // Use this for initialization
    void Start()
    {

        score = 0;
        SetScore();   //初期スコアを代入して表示


    }
    //cube同士での衝突＋100 cube以外との衝突＋100
    void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag;

        if ((yourTag == "LargeCloudTag" ) || (yourTag == "LargeStarTag"))
        {
            score += 100;
        }

        else if ((yourTag == "SmallCloudTag") || (yourTag == "SmallStarTag"))
        {
            score += 50;
        }

        else
        {
            score += 0;
        }

        SetScore();
    }

    void SetScore()
    {
        scoreText.text = string.Format("Score:{0}", score);
    }
}
