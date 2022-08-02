using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene 관련 패키지 불러오는 코드

public class SceneChangeStoryModeToStageThree : MonoBehaviour
{
    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    //GameObject S2BackGroundMusic;
    //AudioSource S2backMusic;

    public void SceneChange()
    {
        SceneManager.LoadScene("StageThree"); // 괄호 속 전환할 scene 이름 적기

        //// 1. DontDestroy 된 오브젝트 찾고
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
        //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. 그리고 그 음악을 멈춘다
        //backMusic.Stop();


        //// 1. DontDestroy 된 오브젝트 찾고
        //S2BackGroundMusic = GameObject.Find("S2BackGroundMusic");

        //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
        //S2backMusic = S2BackGroundMusic.GetComponent<AudioSource>();

        //// 3. 그리고 그 음악을 멈춘다
        //S2backMusic.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
