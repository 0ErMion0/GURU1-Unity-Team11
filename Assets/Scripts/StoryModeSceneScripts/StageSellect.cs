using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSellect : MonoBehaviour
{
    public Button[] StageButtons; // 스테이지 버튼 배열

    // Start is called before the first frame update
    void Start()
    {
        int StageAt = PlayerPrefs.GetInt("StoryMode", 2); // (씬 이름 - 레벨 셀렉하는, BuildSetting에서의 씬 번호)

        for(int i = 0; i < StageButtons.Length; i++)
        {
            if(i + 2 > StageAt)
            {
                StageButtons[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
