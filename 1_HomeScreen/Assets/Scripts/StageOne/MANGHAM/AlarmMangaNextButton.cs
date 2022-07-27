using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmMangaNextButton : MonoBehaviour
{
    Button button;

    private bool state;

    public GameObject AlarmManga; // ������ �� ��1
    public GameObject AlarmMission; // ������ �� ��3

    // public CutSceneShow currentTime;

    // ���� �ð�
    public float currentTime;
    // AlarmManga ���� �ð�
    float AlarmMissionCreateTime = 5;

    public void OnClickButton()
    { 

        //AlarmMission = GameObject.Find("CutSceneAlarmMission"); // ������ ������Ʈ(AlarmMission) ����

        //// ���� �ð��� ���� �ð��� �Ǹ� alarmmission ����
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

        //currentTime.currentTime = 0; // CutSceneShow�� currentTime�� 0���� ����
    }

    void Start()
    {
        AlarmManga = GameObject.Find("CutSceneAlarmManga"); // ������ ������Ʈ(AlarmManga) ����
        AlarmMission = GameObject.Find("CutSceneAlarmMission"); // ������ ������Ʈ(AlarmMission) ����

        //currentTime = GetComponent<CutSceneShow>();

        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    
    void Update()
    {
        //// deltaTime Ȱ���Ͽ� �ð� ������Ŵ
        //currentTime += Time.deltaTime;
    }
}
