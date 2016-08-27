﻿using UnityEngine;
using System.Collections;

public class RSP : MonoBehaviour
{
    public Sprite rock;                                     //グー
    public Sprite scissors;                                 //チョキ
    public Sprite paper;                                    //パー
    public Sprite win;                                     //勝ち
    public Sprite lose;                                    //負け
    public Sprite aiko;                                    //あいこ
  //  public GameObject originHand;
    public GameObject myhand;//画面上に出る自分の手
    public GameObject enemyhand;//画面上に出る相手の手
    public GameObject result;//画面上に出る結果
    private GameObject appearHand;    //画面上に出ている手
    private bool isHiddenOn = false;


    void Start()
    {
        //enemyhand = Instantiate(originHand, originHand.transform.position, Quaternion.identity) as GameObject; //インスタンス生成
       // enemyhand.GetComponent<SpriteRenderer>().sprite = GetNextHand(); //手の絵を入れる
      //  originHand.GetComponent<Renderer>().enabled = false; //見えなくする
    }


    //手札のランダム選出
    Sprite GetNextHand()
    {
        Sprite hand = null;
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                hand = rock;
                break;

            case 1:
                hand = scissors;
                break;

            case 2:
                hand = paper;
                break;
        }
        return hand;
    }
    //相手のランダム選出したものを画面に表示
    void MoveHand()
    {
        enemyhand.GetComponent<SpriteRenderer>().sprite = GetNextHand();
    }
    //自分の出す手を選ぶ
    void Update()
    {
        string enemyHand;//= enemyhand.GetComponent<SpriteRenderer>().sprite.name; //現在の手の名前を取得
         //グー
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveHand();
            enemyHand = enemyhand.GetComponent<SpriteRenderer>().sprite.name;
            if (enemyHand == "Rock")
            {
                Drow();
            }
            else if (enemyHand == "Scissors")
            {
                Win();
            }
            else if (enemyHand == "Paper")
            {
                Lose();
            }
            myhand.GetComponent<SpriteRenderer>().sprite = rock;
        }
        //チョキ.
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveHand();
            enemyHand = enemyhand.GetComponent<SpriteRenderer>().sprite.name;
            if (enemyHand == "Rock")
            {
                Lose();
            }
            else if (enemyHand == "Scissors")
            {
                Drow();
            }
            else if (enemyHand == "Paper")
            {
                Win();
            }
            myhand.GetComponent<SpriteRenderer>().sprite = scissors;
        }
        //パー.
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveHand();
            enemyHand = enemyhand.GetComponent<SpriteRenderer>().sprite.name;
            if (enemyHand == "Rock")
            {
                Win();
            }
            else if (enemyHand == "Scissors")
            {
                Lose();
            }
            else if (enemyHand == "Paper")
            {
                Drow();
            }
            myhand.GetComponent<SpriteRenderer>().sprite = paper;
        }
    }
    //結果表示
    void Win()
    {
        result.GetComponent<SpriteRenderer>().sprite = win;
    }

    void Drow()
    {
        result.GetComponent<SpriteRenderer>().sprite = aiko;
    }

    void Lose()
    {
        result.GetComponent<SpriteRenderer>().sprite = lose;
    }
}