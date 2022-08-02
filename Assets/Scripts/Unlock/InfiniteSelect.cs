using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteSelect : MonoBehaviour
{
    public Button[] StageButtons;

    // Start is called before the first frame update
    void Start()                        //����ȣ:ClearEnding(7)
    {
        int InfiniteAct = PlayerPrefs.GetInt("InfiniteAct", 6);            //InfiniteAct�� 6 ���� (���尪 �����ϰ� >> PlayerPrefs)

        for (int i = 0; i < StageButtons.Length; i++)               //�������� ��ư ������ŭ �ݺ��� ����
        {
            if (i + 7 > InfiniteAct)                                   //i+6 InfiniteAct Ŭ �� ��ư ���ʷ� ��ȣ�ۿ� ��Ȱ��ȭ
                StageButtons[i].interactable = false;               //ó�� �������� �� InfiniteAct 6��, 7>6�� �����ϹǷ� ��Ȱ��ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
