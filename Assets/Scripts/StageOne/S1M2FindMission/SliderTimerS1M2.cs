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
        // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if (slTimerS1M2.value > 0.0f)
        {
            // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
            slTimerS1M2.value -= Time.deltaTime;
        }

        // �ð��� �� �ƴٸ� ���� â����
        if (slTimerS1M2.value == 0)
        {
            SceneManager.LoadScene("FailEnding3");

            //// 1. DontDestroy �� ������Ʈ ã��
            //S1M2BackGroundMusic = GameObject.Find("S1M2BackGroundMusic");

            //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
            //backMusic = S1M2BackGroundMusic.GetComponent<AudioSource>();

            //// 3. �׸��� �� ������ �����
            //backMusic.Stop();
        }
    }
}
