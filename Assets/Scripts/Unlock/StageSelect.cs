using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public Button[] StageButtons;

    // Start is called before the first frame update
    void Start()                        //씬번호:StageOne(23), StageTwo(24), StageThree(25)
    {
        //PlayerPrefs.DeleteAll();            //초기화해야될 때 주석 빼고 실행했다가 다시 주석처리하기
        
        int StageAct = PlayerPrefs.GetInt("StageAct", 23);            //24는 StageOne 씬 번호 / StageAt에 24 저장 (저장값 유지하게 >> PlayerPrefs)

        for (int i = 0; i < StageButtons.Length; i++)               //스테이지 버튼 개수만큼 반복문 돌기
        {
            if (i + 23 > StageAct)                                   //i+23 StageAt보다 클 때 버튼 차례로 상호작용 비활성화
                StageButtons[i].interactable = false;               //처음 실행했을 때 StageAt는 23고, 23>23는 성립하지 않으므로 가장 첫 번째 버튼인 St1만 활성화
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
