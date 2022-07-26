using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAlarmMission1 : MonoBehaviour
{
    // ������ ������Ʈ ����
    public GameObject AlarmMission; // STAGE1 ���� �غ�

    // ���� �ð�
    public float currentTime;

    // Stage1 ���� �ð�
    public float AlarmMissionCreateTime = 3;

    void Start()
    {
        AlarmMission = GameObject.Find("CutSceneAlarmMission"); // ������ ������Ʈ(AlarmMission) ����
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime Ȱ���Ͽ� �ð� ������Ŵ
        currentTime += Time.deltaTime;

        // ���� �ð��� ���� �ð��� �Ǹ� AlarmMission ����
        if (currentTime >= AlarmMissionCreateTime)
        {
            Destroy(AlarmMission);
        }
    }
}
