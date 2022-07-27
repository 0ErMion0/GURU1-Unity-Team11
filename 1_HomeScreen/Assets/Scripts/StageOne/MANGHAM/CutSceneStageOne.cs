using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneStageOne : MonoBehaviour
{
    /* �帧:
    1. ������Ʈ ����
    2. currentTime ~ �̷��ɷ� �ð� �������Ѽ�
    3. ���� �ð��� �Ǹ�
    4. Destory(gameObject) �̷� ��������
    */

    // ������ ������Ʈ ����
    public GameObject Stage1; // STAGE1 ���� �غ�

    // ���� �ð�
    public float currentTime;

    // Stage1 ���� �ð�
    public float Stage1CreateTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        Stage1 = GameObject.Find("CutSceneStageOne"); // ������ ������Ʈ(Stage1) ����
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime Ȱ���Ͽ� �ð� ������Ŵ
        currentTime += Time.deltaTime;

        // ���� �ð��� ���� �ð��� �Ǹ� Stage1 ����
        if(currentTime >= Stage1CreateTime)
        {
            Destroy(Stage1);
        }
    }
}
