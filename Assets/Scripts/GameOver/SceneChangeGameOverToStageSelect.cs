using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene 관련 패키지 불러오는 코드

public class SceneChangeGameOverToStageSelect : MonoBehaviour
{
    //GameObject BackGroundMusicStageSelectControl;
    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    public void SceneChange()
    {
        //BackGroundMusicStageSelectControl = GameObject.Find("BackGroundMusicStageSelectionControl");
        //BackGroundMusicStageSelectControl.SetActive(true);
        SceneManager.LoadScene("StoryMode"); // 괄호 속 전환할 scene 이름 적기

        //SceneManager.GetActiveScene("StoryMode").
        //GameObject[] list = SceneManager.LoadScene(3).GetRootGameObjects(); // 씬메니저 통해 루트오브젝트 불러와 확인 후 접근
        //foreach(GameObject e in list)
        //{
        //    e.BackGroundMusicStageSelectControl.SetActive(true);
        //}

        //// 1. DontDestroy 된 오브젝트 찾고
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
        //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. 그리고 그 음악을 멈춘다
        //backMusic.Play();
    }

    //public void MusicOn()
    //{
    //    BackGroundMusicStageSelectControl = GameObject.Find("BackGroundMusicStageSelectionControl");
    //    BackGroundMusicStageSelectControl.SetActive(true);
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
