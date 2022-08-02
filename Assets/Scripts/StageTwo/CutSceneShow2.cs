using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneShow2 : MonoBehaviour
{
    //private bool state;

    // ������ ������Ʈ ����
    public GameObject Stage2;
    public GameObject BusManga;

    // ���� �ð�
    public float currentTime;

    // ���� �ð�
    public float CreateTime = 3; // Stage2 ���� �ð�


    // Start is called before the first frame update
    void Start()
    {
        // ����
        Stage2 = GameObject.Find("CutSceneStageTwo"); // ������ ������Ʈ(Stage1) ����
        BusManga = GameObject.Find("CutSceneBusManga"); // ������ ������Ʈ(AlarmManga) ����
        //state = true;
    }

    // Update is called once per frame
    void Update()
    {
        // deltaTime Ȱ���Ͽ� �ð� ������Ŵ
        currentTime += Time.deltaTime;

        // Stage2 ����
        if (currentTime > CreateTime)
        {
            Stage2.SetActive(false);
            //state = false;
        }

        // BusManga �������
        if (currentTime <= CreateTime)
        {
            BusManga.SetActive(false);
        }

        // AlarmManga ��Ÿ��
        if (currentTime > CreateTime)
        {
            //if (currentTime < AlarmMangaCreateTime) // �̰� ���ָ� Uplod ��� �Ǹ鼭 ��ȭ�� �������� ����
            //{
            //    AlarmManga.SetActive(true);
            //}

            BusManga.SetActive(true);

            //state = false;
        }
    }
}
