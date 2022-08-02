using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public Button[] StageButtons;

    // Start is called before the first frame update
    void Start()                        //����ȣ:StageOne(23), StageTwo(24), StageThree(25)
    {
        //PlayerPrefs.DeleteAll();            //�ʱ�ȭ�ؾߵ� �� �ּ� ���� �����ߴٰ� �ٽ� �ּ�ó���ϱ�
        
        int StageAct = PlayerPrefs.GetInt("StageAct", 23);            //24�� StageOne �� ��ȣ / StageAt�� 24 ���� (���尪 �����ϰ� >> PlayerPrefs)

        for (int i = 0; i < StageButtons.Length; i++)               //�������� ��ư ������ŭ �ݺ��� ����
        {
            if (i + 23 > StageAct)                                   //i+23 StageAt���� Ŭ �� ��ư ���ʷ� ��ȣ�ۿ� ��Ȱ��ȭ
                StageButtons[i].interactable = false;               //ó�� �������� �� StageAt�� 23��, 23>23�� �������� �����Ƿ� ���� ù ��° ��ư�� St1�� Ȱ��ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
