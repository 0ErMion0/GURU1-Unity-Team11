using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAlarmMission : MonoBehaviour
{
    // ������ ������Ʈ ����
    public GameObject AlarmMission; // ������ �� ��3

    // ���� �ð�
    public float currentTime;

    // AlarmManga ���� �ð�
    public float AlarmMissionCreateTime = 1;


    void Start()
    {
        AlarmMission = GameObject.Find("CutSceneAlarmMission"); // ������ ������Ʈ(AlarmManga) ����
    }

    // Update is called once per frame
    void Update()
    {
        //// deltaTime Ȱ���Ͽ� �ð� ������Ŵ
        //currentTime += Time.deltaTime;

        //// ���� �ð��� ���� �ð��� �Ǹ� AlarmMission ����
        //if (currentTime < AlarmMissionCreateTime)
        //{
        //    AlarmMission.SetActive(false);
        //    //Destroy(AlarmMission);
        //}
    }
}
