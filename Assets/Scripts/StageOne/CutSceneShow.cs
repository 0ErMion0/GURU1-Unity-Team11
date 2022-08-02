using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneShow : MonoBehaviour
{
    //private bool state;

    // ������ ������Ʈ ����
    public GameObject Stage1; // STAGE1 ���� �غ�
    public GameObject AlarmManga; // ������ �� ��1
    //public GameObject AlarmMission; // ������ �� ��3

    // ���� �ð�
    public float currentTime;
    public float currentTime2; // AlarmMission ������

    // ���� �ð�
    public float Stage1CreateTime = 3; // Stage1 ���� �ð�
    //public float AlarmMangaCreateTime = 6; // AlarmManga ���� �ð�
    //public float AlarmMissionCreateTime = 9; // AlarmManga ���� �ð�


    void Start()
    {
        // ����
        Stage1 = GameObject.Find("CutSceneStageOne"); // ������ ������Ʈ(Stage1) ����
        AlarmManga = GameObject.Find("CutSceneAlarmManga"); // ������ ������Ʈ(AlarmManga) ����
        //state = true;
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime Ȱ���Ͽ� �ð� ������Ŵ
        currentTime += Time.deltaTime;

        // 0~3: Stage1
        // 4~6: AlarmManga

        // Stage1 ����
        if (currentTime > Stage1CreateTime)
        {
            Stage1.SetActive(false);
            //state = false;
        }

        // AlarmManga �������
        if (currentTime <= Stage1CreateTime)
        {
            AlarmManga.SetActive(false);
        }

        // AlarmManga ��Ÿ��
        if (currentTime > Stage1CreateTime)
        {
            AlarmManga.SetActive(true);

            //state = false;
        } 
    }
}
