using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SliderOff : MonoBehaviour
{
    Slider slOff;

    //GameObject S1ToS1M1BackGroundMusic;
    //AudioSource backMusic;

    // Start is called before the first frame update
    void Start()
    {
        slOff = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다. ---- 다른 스크립트에 추가하기
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (slOff.value == 1) // 손잡이가 1에 있다면
        {
            // 다음 화면으로 넘어가게
            //Debug.Log("haha");
            SceneManager.LoadScene("S1M2FindMission");

            //// 1. DontDestroy 된 오브젝트 찾고
            //S1ToS1M1BackGroundMusic = GameObject.Find("S1ToS1M1BackGroundMusic");

            //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
            //backMusic = S1ToS1M1BackGroundMusic.GetComponent<AudioSource>();

            //// 3. 그리고 그 음악을 멈춘다
            //backMusic.Stop();
        }

        
    }
}
