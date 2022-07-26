using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneShow : MonoBehaviour
{
    private bool state;

    // 삭제할 오브젝트 선언
    public GameObject Stage1; // STAGE1 외출 준비
    public GameObject AlarmManga; // 보여줄 컷 씬1
    //public GameObject AlarmMission; // 보여줄 컷 씬3

    // 현재 시간
    public float currentTime;
    public float currentTime2; // AlarmMission 숨기기용

    // 일정 시간
    public float Stage1CreateTime = 3; // Stage1 일정 시간
    //public float AlarmMangaCreateTime = 6; // AlarmManga 일정 시간
    //public float AlarmMissionCreateTime = 9; // AlarmManga 일정 시간


    void Start()
    {
        // 참조
        Stage1 = GameObject.Find("CutSceneStageOne"); // 삭제할 오브젝트(Stage1) 참조
        AlarmManga = GameObject.Find("CutSceneAlarmManga"); // 삭제할 오브젝트(AlarmManga) 참조
        state = true;
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime 활용하여 시간 누적시킴
        currentTime += Time.deltaTime;

        // 0~3: Stage1
        // 4~6: AlarmManga

        // Stage1 숨김
        if (currentTime > Stage1CreateTime)
        {
            Stage1.SetActive(false);
            //state = false;
        }

        // AlarmManga 예비숨김
        if (currentTime <= Stage1CreateTime)
        {
            AlarmManga.SetActive(false);
        }


        //// AlarmMission 예비숨김
        //if (currentTime <= Stage1CreateTime)
        //{
        //    AlarmMission.SetActive(false);
        //}


        // AlarmManga 나타냄
        if (currentTime > Stage1CreateTime)
        {
            //if (currentTime < AlarmMangaCreateTime) // 이거 없애면 Uplod 계속 되면서 만화가 없어지지 않음
            //{
            //    AlarmManga.SetActive(true);
            //}

            AlarmManga.SetActive(true);

            state = false;
        }

        //// 이렇게 하면 3~6초 사이에 클릭했을 때 알람미션창이 제거되는 문제 생김
        //// AlarmManga 숨기고 AlarmMission 나타냄
        ////if (currentTime > Stage1CreateTime) // 3초 전에 클릭하면 AlarmMission이 제거되는 문제 해결 위해
        ////{
        //    if (state == false)
        //    {
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            AlarmManga.SetActive(false);
        //            AlarmMission.SetActive(true);

        //            //// deltaTime 활용하여 시간 누적시킴
        //            //currentTime2 += Time.deltaTime;

        //            //if (currentTime2 > AlarmMissionCreateTime)
        //            //{
        //            //    AlarmMission.SetActive(false);
        //            //}

        //            Destroy(AlarmMission, 3); // 3초 뒤에 없애기
        //        }
        //    }
        ////}
        
    }
}
