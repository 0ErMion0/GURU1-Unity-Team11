using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMControl : MonoBehaviour
{
    // 1
    private AudioSource audioSource;
    public GameObject Main;
    public GameObject ST1_Alarm;
    public GameObject ST1Find;
    public GameObject ST2;
    public GameObject ST3;

    int count = 0;

    // 2
    //public static MusicControlScript Instance;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        //SceneManager.LoadScene("HomeScreen");

        // 1
        //DontDestroyOnLoad(transform.gameObject);
        //audioSource = GetComponent<AudioSource>();

        // 2
        //Instance = this;

        // 3
        //var BackGroundMusicControl = FindObjectsOfType<BackGroundMusicControl>();
        //if (BackGroundMusicControl.Length == 1)
        //{
        //    DontDestroyOnLoad(gameObject); // �̷��� �ϸ� �ٽ� ����ȭ�� ���ư��� �������� ���� â ���� �������� ���� â���� �뷡 �ȳ���.. �׸��� BackGroundMusicControl ���� �����Ǿ��ϴµ� ��Ʈ���� �ּ� ó���ϸ�.,. �� ����..
        //    //audioSource = GetComponent<AudioSource>();
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }
    
    void Update()
    {
        if(count==0)
        {
            DontDestroyOnLoad(transform.gameObject);
            count++;
        }

        if (SceneManager.GetActiveScene().name == "HomeScreen")     //����ȭ�鿡�� ���� ���� Ȱ��ȭ
        {
            if (Main.activeSelf == false)
                Main.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "StoryMode")      //�������� ���ÿ��� ���� ������ Ȱ��ȭ �Ǿ� ���� �ʴٸ�(���� ���� �� �������� ���� ���� ��)
        {  
            if (Main.activeSelf == false)               
                Main.SetActive(true);                               //���� ���� Ȱ��ȭ
        }
        
        if (SceneManager.GetActiveScene().name == "InfiniteMode")    //����>���� ��� ���� ��
            Main.SetActive(false);

        if (SceneManager.GetActiveScene().name == "StageOne")       //��������1 �������� ��(�˶� �̼�)
        {
            Main.SetActive(false);                                  //���� ���� ��Ȱ��ȭ
            ST1_Alarm.SetActive(true);                              //��������1 ���� Ȱ��ȭ
        }

        if (SceneManager.GetActiveScene().name == "FailEnding1")    //�˶� �̼� ���н�
        {
            ST1_Alarm.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "S1M2FindMission")        //ã�� �̼� ���� ��
        {
            ST1_Alarm.SetActive(false);                             //��������1 ���� ��Ȱ��ȭ
            ST1Find.SetActive(true);                                //ã�� �̼� ���� Ȱ��ȭ
        }
        else                            //ã�� �̼� ���� �� || �����ؼ� ���� ������ �Ѿ�� ��
        {
            ST1Find.SetActive(false);                             //��������1 ���� ��Ȱ��ȭ
        }

        if(SceneManager.GetActiveScene().name == "StageTwo")        //��������2
        {
            Main.SetActive(false);                                  //���� ���� ��Ȱ��ȭ(������������>2 �ٷ� ���� ���)
            ST2.SetActive(true);                                    //��������2 ���� Ȱ��ȭ
        }

        if(SceneManager.GetActiveScene().name == "FailEnding3")     //��������2 ����
        {
            ST2.SetActive(false);                                   //��������2 ���� ��Ȱ��ȭ
        }

        if (SceneManager.GetActiveScene().name == "StageThree")      //��������3 ����
        {
            ST2.SetActive(false);                                   //��������2 ���� ��Ȱ��ȭ
            Main.SetActive(false);                                  //���� ���� ��Ȱ��ȭ(�������� ����>3 �ٷ� ���� ���)
            ST3.SetActive(true);                                    //��������3 ���� Ȱ��ȭ
        }

        if(SceneManager.GetActiveScene().name == "FailEnding6")     //��������3 ����
        {
            ST3.SetActive(false);                                   //��������3 ���� ��Ȱ��ȭ
        }

        if (SceneManager.GetActiveScene().name == "ClearEnding")     //��������3 ����
        {
            ST3.SetActive(false);                                   //��������3 ���� ��Ȱ��ȭ
        }

    }
}
