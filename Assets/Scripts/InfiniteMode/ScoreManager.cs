using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text CurrentScoreUI;
    public int CurrentScore;

    public Text BestScoreUI;
    public int BestScore;

    GameObject smObject;
    public bool playC = true;

    // Start is called before the first frame update
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("Best Score", 0);
        BestScoreUI.text = "�ְ� ���� : " + BestScore;
        StartCoroutine(AddScore());

        smObject = GameObject.Find("MenuManager");
    }

    public IEnumerator AddScore()
    {
        while (true)
        {
            if (playC)
                CurrentScore++;      //���ھ� ����

            CurrentScoreUI.text = "���� ���� : " + CurrentScore;

            if (CurrentScore > BestScore)
            {
                BestScore = CurrentScore;
                BestScoreUI.text = "�ְ� ���� : " + BestScore;

                PlayerPrefs.SetInt("Best Score", BestScore);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MainMenuManager sm = smObject.GetComponent<MainMenuManager>();

        if (sm.play)
            playC = true;
        else
            playC = false;
    }
}
