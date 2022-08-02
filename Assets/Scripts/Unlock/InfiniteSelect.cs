using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteSelect : MonoBehaviour
{
    public Button[] StageButtons;

    // Start is called before the first frame update
    void Start()                        //씬번호:ClearEnding(7)
    {
        int InfiniteAct = PlayerPrefs.GetInt("InfiniteAct", 6);            //InfiniteAct에 6 저장 (저장값 유지하게 >> PlayerPrefs)

        for (int i = 0; i < StageButtons.Length; i++)               //스테이지 버튼 개수만큼 반복문 돌기
        {
            if (i + 7 > InfiniteAct)                                   //i+6 InfiniteAct 클 때 버튼 차례로 상호작용 비활성화
                StageButtons[i].interactable = false;               //처음 실행했을 때 InfiniteAct 6고, 7>6는 성립하므로 비활성화
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
