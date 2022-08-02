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
        //    // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
        //    slTimer.value += Time.deltaTime;
        //}

        // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
        slTimer.value += Time.deltaTime;

        // �ð��� �� �ƴٸ� Ŭ���� â���� - ���� �ð� ���� ��Ƽ�� �Ǵ°Ŷ� (���� �� ���� ��ũ��Ʈ�� CatMove��)
        if (slTimer.value == slTimer.maxValue)
        {
            SceneManager.LoadScene("ClearEnding"); // ��������

            //// 1. DontDestroy �� ������Ʈ ã��
            //S3BackGroundMusic = GameObject.Find("S3BackGroundMusic");

            //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
            //backMusic = S3BackGroundMusic.GetComponent<AudioSource>();

            //// 3. �׸��� �� ������ �����
            //backMusic.Stop();
        }
    }
}
