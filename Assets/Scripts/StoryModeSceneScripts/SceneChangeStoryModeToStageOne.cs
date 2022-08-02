using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // scene 관련 패키지 불러오는 코드

//public class SceneChangeStoryModeToStageOne<T> : MonoBehaviour where T : MonoBehaviour // 2

public class SceneChangeStoryModeToStageOne : MonoBehaviour // 1
{
    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    //pirvate static object BackGroundMusicControl = new object(); // 2

    //1
    public void SceneChange()
    {
        SceneManager.LoadScene("StageOne"); // 괄호 속 전환할 scene 이름 적기

        //// 1. DontDestroy 된 오브젝트 찾고
        //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

        //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
        //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

        //// 3. 그리고 그 음악을 멈춘다
        //backMusic.Stop();
    }

    //// 2 
    //public static T Instance
    //{
    //    get
    //    {
    //        if()
    //    }
    //}
}
