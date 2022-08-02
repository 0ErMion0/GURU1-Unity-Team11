using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneShow3 : MonoBehaviour
{
    // 삭제할 오브젝트 선언
    public GameObject Stage3;
    public GameObject CutSceneS3M1;

    // 현재 시간
    public float currentTime;

    // 일정 시간
    public float Stage3CreateTime = 3;
    public float CutSceneS3M1CreateTime = 8;


    // Start is called before the first frame update
    void Start()
    {
        // 참조
        Stage3 = GameObject.Find("CutSceneStageThree");
        CutSceneS3M1 = GameObject.Find("CutSceneS3M1");

        CutSceneS3M1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime 활용하여 시간 누적시킴
        currentTime += Time.deltaTime;

        if(currentTime > Stage3CreateTime && currentTime < CutSceneS3M1CreateTime)
        {
            Stage3.SetActive(false);
            CutSceneS3M1.SetActive(true);
        }

        if(currentTime >= CutSceneS3M1CreateTime)
        {
            SceneManager.LoadScene("S3PacMan"); //S3PacMan
        }

    }
}
