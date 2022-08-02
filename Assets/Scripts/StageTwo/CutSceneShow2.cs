using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneShow2 : MonoBehaviour
{
    //private bool state;

    // 삭제할 오브젝트 선언
    public GameObject Stage2;
    public GameObject BusManga;

    // 현재 시간
    public float currentTime;

    // 일정 시간
    public float CreateTime = 3; // Stage2 일정 시간


    // Start is called before the first frame update
    void Start()
    {
        // 참조
        Stage2 = GameObject.Find("CutSceneStageTwo"); // 삭제할 오브젝트(Stage1) 참조
        BusManga = GameObject.Find("CutSceneBusManga"); // 삭제할 오브젝트(AlarmManga) 참조
        //state = true;
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime 활용하여 시간 누적시킴
        currentTime += Time.deltaTime;

        // Stage2 숨김
        if (currentTime > CreateTime)
        {
            Stage2.SetActive(false);
            //state = false;
        }

        // BusManga 예비숨김
        if (currentTime <= CreateTime)
        {
            BusManga.SetActive(false);
        }

        // AlarmManga 나타냄
        if (currentTime > CreateTime)
        {
            //if (currentTime < AlarmMangaCreateTime) // 이거 없애면 Uplod 계속 되면서 만화가 없어지지 않음
            //{
            //    AlarmManga.SetActive(true);
            //}

            BusManga.SetActive(true);

            //state = false;
        }
    }
}
