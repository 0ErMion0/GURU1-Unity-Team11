using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderTimer : MonoBehaviour
{
    Slider slTimer;
    //float fSliderBarTime;

    //GameObject S1ToS1M1BackGroundMusic;
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

        // �ð��� �� �ƴٸ� ���� â����
        if(slTimer.value == 0)
        {
            SceneManager.LoadScene("FailEnding1");

            //// 1. DontDestroy �� ������Ʈ ã��
            //S1ToS1M1BackGroundMusic = GameObject.Find("S1ToS1M1BackGroundMusic");

            //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
            //backMusic = S1ToS1M1BackGroundMusic.GetComponent<AudioSource>();

            //// 3. �׸��� �� ������ �����
            //backMusic.Stop();
        }
    }
}
