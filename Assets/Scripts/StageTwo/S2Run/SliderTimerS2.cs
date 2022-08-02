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
            // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
            slTimer.value -= Time.deltaTime;
        }

        // �ð��� �� �ƴٸ� ���� â���� - ���� ��
        if (slTimer.value == 0)
        {
            SceneManager.LoadScene("S2M2Fix"); // ��ȣ�� ��ġ�� �̼����� �̵�
        }
    }
}
