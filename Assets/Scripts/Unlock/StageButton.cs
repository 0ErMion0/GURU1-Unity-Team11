using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public int nextStage;

    // Start is called before the first frame update
    void Start()        //StageTwo/StageThree 씬에 있는 오브젝트 소속
    {
        nextStage = SceneManager.GetActiveScene().buildIndex;           //nextStage에 현재 씬 번호 받아옴(25/26)

        if (nextStage > PlayerPrefs.GetInt("StageAct"))                 //nextStage(25/26)가 StageAct(첫 실행에 24)보다 클 경우 
            PlayerPrefs.SetInt("StageAct", nextStage);                  //StageAct를 nextStage로 바꿈 (PlayerPrefs 사용했으므로 값 유지) 
    }                                                                   //이후 LevelSelction 스크립트 반복문에 의해 선택 창으로 돌아갔을 때 2/3개 활성화됨

    // Update is called once per frame
    void Update()
    {

    }
}