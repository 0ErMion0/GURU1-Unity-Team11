using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderTimerS2 : MonoBehaviour
{
    Slider slTimer;
    float fSliderBarTime;

    // Start is called before the first frame update
    void Start()
    {
        slTimer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            // 시간이 변경한 만큼 slider Value 변경을 합니다.
            slTimer.value -= Time.deltaTime;
        }

        // 시간이 다 됐다면 엔딩 창으로 - 실패 시
        if (slTimer.value == 0)
        {
            SceneManager.LoadScene("S2M2Fix"); // 신호등 고치는 미션으로 이동
        }
    }
}
