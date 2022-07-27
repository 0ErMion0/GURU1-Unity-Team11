using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSellect : MonoBehaviour
{
    public Button[] StageButtons; // �������� ��ư �迭

    // Start is called before the first frame update
    void Start()
    {
        int StageAt = PlayerPrefs.GetInt("StoryMode", 2); // (�� �̸� - ���� �����ϴ�, BuildSetting������ �� ��ȣ)

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
