using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAlarmMission1 : MonoBehaviour
{
    // 삭제할 오브젝트 선언
    public GameObject AlarmMission; // STAGE1 외출 준비

    // 현재 시간
    public float currentTime;

    // Stage1 일정 시간
    public float AlarmMissionCreateTime = 3;

    void Start()
    {
        AlarmMission = GameObject.Find("CutSceneAlarmMission"); // 삭제할 오브젝트(AlarmMission) 참조
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime 활용하여 시간 누적시킴
        currentTime += Time.deltaTime;

        // 현재 시간이 일정 시간이 되면 AlarmMission 제거
        if (currentTime >= AlarmMissionCreateTime)
        {
            Destroy(AlarmMission);
        }
    }
}
