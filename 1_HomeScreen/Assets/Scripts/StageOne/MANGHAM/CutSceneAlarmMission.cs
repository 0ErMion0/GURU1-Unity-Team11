using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAlarmMission : MonoBehaviour
{
    // 삭제할 오브젝트 선언
    public GameObject AlarmMission; // 보여줄 컷 씬3

    // 현재 시간
    public float currentTime;

    // AlarmManga 일정 시간
    public float AlarmMissionCreateTime = 1;


    void Start()
    {
        AlarmMission = GameObject.Find("CutSceneAlarmMission"); // 삭제할 오브젝트(AlarmManga) 참조
    }

    // Update is called once per frame
    void Update()
    {
        //// deltaTime 활용하여 시간 누적시킴
        //currentTime += Time.deltaTime;

        //// 현재 시간이 일정 시간이 되면 AlarmMission 제거
        //if (currentTime < AlarmMissionCreateTime)
        //{
        //    AlarmMission.SetActive(false);
        //    //Destroy(AlarmMission);
        //}
    }
}
