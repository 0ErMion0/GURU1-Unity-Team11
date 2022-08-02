using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderMovement : MonoBehaviour
{
    Slider slMovement;

    // Start is called before the first frame update
    void Start()
    {
        slMovement = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�. ---- �ٸ� ��ũ��Ʈ�� �߰��ϱ�
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            slMovement.value += 1;
        }

        // ���� ��
        if(slMovement.value == slMovement.maxValue)
        {
            SceneManager.LoadScene("FailEnding4");
        }
    }
}
