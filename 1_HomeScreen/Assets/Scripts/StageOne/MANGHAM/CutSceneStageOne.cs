using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneStageOne : MonoBehaviour
{
    /* 흐름:
    1. 오브젝트 출현
    2. currentTime ~ 이런걸로 시간 누적시켜서
    3. 일정 시간이 되면
    4. Destory(gameObject) 이런 느낌으로
    */

    // 삭제할 오브젝트 선언
    public GameObject Stage1; // STAGE1 외출 준비

    // 현재 시간
    public float currentTime;

    // Stage1 일정 시간
    public float Stage1CreateTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        Stage1 = GameObject.Find("CutSceneStageOne"); // 삭제할 오브젝트(Stage1) 참조
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime 활용하여 시간 누적시킴
        currentTime += Time.deltaTime;

        // 현재 시간이 일정 시간이 되면 Stage1 제거
        if(currentTime >= Stage1CreateTime)
        {
            Destroy(Stage1);
        }
    }
}
