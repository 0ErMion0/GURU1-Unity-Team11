using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderTimerS2M1 : MonoBehaviour
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
        // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (slTimer.value > 0.0f)
        {
            // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
            slTimer.value -= Time.deltaTime;
        }

        // �ð��� �� �ƴٸ� ���� â���� - ���� ��
        if(slTimer.value == 0)
        {
            SceneManager.LoadScene("FailEnding2");
        }
    }
}
