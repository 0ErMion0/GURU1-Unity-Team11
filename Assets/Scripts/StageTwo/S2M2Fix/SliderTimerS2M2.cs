using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderTimerS2M2 : MonoBehaviour
{
    Slider slTimer;
    //float fSliderBarTime;

    //GameObject S2BackGroundMusic;
    //AudioSource backMusic;

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
        if (slTimer.value == 0)
        {
            SceneManager.LoadScene("FailEnding3");

            //// 1. DontDestroy �� ������Ʈ ã��
            //S2BackGroundMusic = GameObject.Find("S2BackGroundMusic");

            //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
            //backMusic = S2BackGroundMusic.GetComponent<AudioSource>();

            //// 3. �׸��� �� ������ �����
            //backMusic.Stop();
        }
    }
}
