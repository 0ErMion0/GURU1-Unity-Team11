using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmMangaNextButton : MonoBehaviour
{
    Button button;

    private bool state;

    public GameObject AlarmManga; // 보여줄 컷 씬1
    public GameObject AlarmMission; // 보여줄 컷 씬3

    // public CutSceneShow currentTime;

    // 현재 시간
    public float currentTime;
    // AlarmManga 일정 시간
    float AlarmMissionCreateTime = 5;

    public void OnClickButton()
    { 

        //AlarmMission = GameObject.Find("CutSceneAlarmMission"); // 삭제할 오브젝트(AlarmMission) 참조

        //// 현재 시간이 일정 시간이 되면 alarmmission 제거
        //if (currentTime < AlarmMissionCreateTime)
        //{
        //    AlarmMission.SetActive(false);
        //    //Destroy(AlarmMission);
        //}

        //Destroy(AlarmManga);

        AlarmManga.SetActive(false);
        AlarmMission.SetActive(true);
        //AlarmManga.SetActive(false);

        //if (currentTime > AlarmMissionCreateTime)
        //{
        //    AlarmMission.SetActive(false);
        //    //Destroy(AlarmMission);
        //}

        //currentTime.currentTime = 0; // CutSceneShow의 currentTime을 0으로 설정
    }

    void Start()
    {
        AlarmManga = GameObject.Find("CutSceneAlarmManga"); // 삭제할 오브젝트(AlarmManga) 참조
        AlarmMission = GameObject.Find("CutSceneAlarmMission"); // 삭제할 오브젝트(AlarmMission) 참조

        //currentTime = GetComponent<CutSceneShow>();

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    
    void Update()
    {
        //// deltaTime 활용하여 시간 누적시킴
        //currentTime += Time.deltaTime;
    }
}
