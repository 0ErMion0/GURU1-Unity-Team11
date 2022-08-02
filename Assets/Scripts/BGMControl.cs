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
        //    DontDestroyOnLoad(gameObject); // 이렇게 하면 다시 메인화면 돌아가고 스테이지 선택 창 가면 스테이지 선택 창에선 노래 안나와.. 그리고 BackGroundMusicControl 새로 생성되야하는데 디스트로이 주석 처리하면.,. 안 나와..
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

        if (SceneManager.GetActiveScene().name == "HomeScreen")     //메인화면에서 메인 음악 활성화
        {
            if (Main.activeSelf == false)
                Main.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "StoryMode")      //스테이지 선택에서 메인 음악이 활성화 되어 있지 않다면(게임 오버 후 스테이지 선택 왔을 때)
        {  
            if (Main.activeSelf == false)               
                Main.SetActive(true);                               //메인 음악 활성화
        }
        
        if (SceneManager.GetActiveScene().name == "InfiniteMode")    //메인>무한 모드 갔을 때
            Main.SetActive(false);

        if (SceneManager.GetActiveScene().name == "StageOne")       //스테이지1 돌입했을 때(알람 미션)
        {
            Main.SetActive(false);                                  //메인 음악 비활성화
            ST1_Alarm.SetActive(true);                              //스테이지1 음악 활성화
        }

        if (SceneManager.GetActiveScene().name == "FailEnding1")    //알람 미션 실패시
        {
            ST1_Alarm.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "S1M2FindMission")        //찾기 미션 돌입 시
        {
            ST1_Alarm.SetActive(false);                             //스테이지1 음악 비활성화
            ST1Find.SetActive(true);                                //찾기 미션 음악 활성화
        }
        else                            //찾기 미션 실패 시 || 성공해서 다음 씬으로 넘어갔을 때
        {
            ST1Find.SetActive(false);                             //스테이지1 음악 비활성화
        }

        if(SceneManager.GetActiveScene().name == "StageTwo")        //스테이지2
        {
            Main.SetActive(false);                                  //메인 음악 비활성화(스테이지선택>2 바로 오는 경우)
            ST2.SetActive(true);                                    //스테이지2 음악 활성화
        }

        if(SceneManager.GetActiveScene().name == "FailEnding3")     //스테이지2 실패
        {
            ST2.SetActive(false);                                   //스테이지2 음악 비활성화
        }

        if (SceneManager.GetActiveScene().name == "StageThree")      //스테이지3 돌입
        {
            ST2.SetActive(false);                                   //스테이지2 음악 비활성화
            Main.SetActive(false);                                  //메인 음악 비활성화(스테이지 선택>3 바로 오는 경우)
            ST3.SetActive(true);                                    //스테이지3 음악 활성화
        }

        if(SceneManager.GetActiveScene().name == "FailEnding6")     //스테이지3 실패
        {
            ST3.SetActive(false);                                   //스테이지3 음악 비활성화
        }

        if (SceneManager.GetActiveScene().name == "ClearEnding")     //스테이지3 성공
        {
            ST3.SetActive(false);                                   //스테이지3 음악 비활성화
        }

    }
}
