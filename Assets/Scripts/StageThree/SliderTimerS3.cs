using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderTimerS3 : MonoBehaviour
{
    Slider slTimer;
    //float fSliderBarTime;

    //S3BackGroundMusic
    //GameObject S3BackGroundMusic;
    //AudioSource backMusic;

    // Start is called before the first frame update
    void Start()
    {
        slTimer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (slTimer.value > 0.0f)
        //{
        //    // 시간이 변경한 만큼 slider Value 변경을 합니다.
        //    slTimer.value += Time.deltaTime;
        //}

        // 시간이 변경한 만큼 slider Value 변경을 합니다.
        slTimer.value += Time.deltaTime;

        // 시간이 다 됐다면 클리어 창으로 - 제한 시간 동안 버티면 되는거라 (생명 다 깎인 스크립트는 CatMove에)
        if (slTimer.value == slTimer.maxValue)
        {
            SceneManager.LoadScene("ClearEnding"); // 엔딩으로

            //// 1. DontDestroy 된 오브젝트 찾고
            //S3BackGroundMusic = GameObject.Find("S3BackGroundMusic");

            //// 2. 그 안에 포함된 AudioSource 변수에 넣는다
            //backMusic = S3BackGroundMusic.GetComponent<AudioSource>();

            //// 3. 그리고 그 음악을 멈춘다
            //backMusic.Stop();
        }
    }
}
