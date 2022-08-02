using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    GameObject BackGroundMusic;
    AudioSource backMusic;

    //GameObject BackGroundMusicControl;
    //AudioSource backMusicMain;

    public bool play = true;
    public GameObject GameMenu;     //일시정지 메뉴

    public Button MainMenu;
    public Button Continue;

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.onClick.AddListener(OnClickMainMenu);
        Continue.onClick.AddListener(OnClickContinue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))           //ESC를 눌렀을 떄
        {
            if (GameMenu.activeSelf)                 //이미 게임 메뉴가 활성화 되어 있다면
            {
                GameMenu.SetActive(false);          //게임 메뉴 비활성화
                play = true;                        //플레이=true

                BackGroundMusic = GameObject.Find("BackGroundMusic");
                backMusic = BackGroundMusic.GetComponent<AudioSource>();
                backMusic.Play();
            }
            else                                    //아니라면
            {
                GameMenu.SetActive(true);           //게임 메뉴 활성화
                play = false;                       //플레이=false

                BackGroundMusic = GameObject.Find("BackGroundMusic");
                backMusic = BackGroundMusic.GetComponent<AudioSource>();
                backMusic.Pause();
            }
        }
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("HomeScreen");          //메인 메뉴로 씬 전환

        //// 1. DontDestroy 된 오브젝트 찾고
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
        //backMusicMain = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. 그리고 그 음악을 멈춘다
        //backMusicMain.Play();

        //Debug.Log("MainMenu");
    }

    public void OnClickContinue()
    {
        GameMenu.SetActive(false);          //게임 메뉴 비활성화
        play = true;                        //플레이=true

        BackGroundMusic = GameObject.Find("BackGroundMusic");
        backMusic = BackGroundMusic.GetComponent<AudioSource>();
        backMusic.Pause();
        backMusic.Play();
    }
}
