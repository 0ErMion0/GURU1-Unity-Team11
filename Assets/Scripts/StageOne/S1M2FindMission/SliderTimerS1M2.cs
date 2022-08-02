using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderTimerS1M2 : MonoBehaviour
{
    Slider slTimerS1M2;
    //float fSliderBarTime;

    //GameObject S1M2BackGroundMusic;
    //AudioSource backMusic;

    // Start is called before the first frame update
    void Start()
    {
        slTimerS1M2 = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 상태가 ‘게임 중’ 상태일 때만 조작할 수 있게 한다.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (slTimerS1M2.value > 0.0f)
        {
            // 시간이 변경한 만큼 slider Value 변경을 합니다.
            slTimerS1M2.value -= Time.deltaTime;
        }

        // 시간이 다 됐다면 엔딩 창으로
        if (slTimerS1M2.value == 0)
        {
            SceneManager.LoadScene("FailEnding3");

            //// 1. DontDestroy 된 오브젝트 찾고
            //S1M2BackGroundMusic = GameObject.Find("S1M2BackGroundMusic");

            //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
            //backMusic = S1M2BackGroundMusic.GetComponent<AudioSource>();

            //// 3. 그리고 그 음악을 멈춘다
            //backMusic.Stop();
        }
    }
}
