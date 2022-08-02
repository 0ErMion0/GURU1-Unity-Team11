using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    // �̱��� ����
    public static GameManager gm;

    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
    }

    // ���� ���� ���
    public enum GameState
    {
        Ready, // �� ȭ�� ������
        Run, // �̼� �÷���
        GameOver // ����
    }

    // ������ ���� ���� ����
    public GameState gState;

    // ���� ���� UI ������Ʈ ����
    public GameObject gameLabel;

    // ���� ���� UI �ؽ�Ʈ ������Ʈ ����
    //Text gameText;

    // ���� ���� UI �̹��� ������Ʈ ����
    Image gameImage;

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ���� ���´� �غ� ���·� �����Ѵ�.
        gState = GameState.Ready;

        // ���� ���� UI ������Ʈ���� Image ������Ʈ�� �����´�
        gameImage = gameLabel.GetComponent<Image>();

        // ���� �غ� -> ���� �� ���·� ��ȯ
        StartCoroutine(ReadyToStart());

        //// �÷��̾� ������Ʈ�� ã�� �� �÷��̾��� PlayerMove ������Ʈ �޾ƿ���
        //player = GameObject.Find("Player").GetComponent<PlayerMove>();

        //SliderTimer = GameObject.Find("SliderOff").GetComponent<SliderOff>; // <����?> �����̴� �����ϰ� ������ ��� ����;;
        
    }

    IEnumerator ReadyToStart()
    {
        // 3�ʰ� ��� ---------- �� ��ȯ �ð� �ٲ۴ٸ� �ٲٱ�
        yield return new WaitForSeconds(3f);

        // ���� �ؽ�Ʈ�� ��Ȱ��ȭ�Ѵ�.
        gameLabel.SetActive(false);

        // ���¸� �������ߡ� ���·� �����Ѵ�.
        gState = GameState.Run;
    }

    // Update is called once per frame
    void Update()
    {
        //// ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�. ---- �ٸ� ��ũ��Ʈ�� �߰��ϱ�
        //if (GameManager.gm.gState != GameManager.GameState.Run)
        //{
        //    return;
        //}

        //// ����, �÷��̾��� hp�� 0 ���϶��...
        //if (player.hp <= 0)
        //{
        //    // ���� �ؽ�Ʈ�� Ȱ��ȭ�Ѵ�.
        //    gameLabel.SetActive(true);
        //    // ���� �ؽ�Ʈ�� ������ ��Game Over���� �Ѵ�.
        //    gameText.text = "Game Over";
        //    // ���� �ؽ�Ʈ�� ������ ���������� �Ѵ�.
        //    gameText.color = new Color32(255, 0, 0, 255);
        //    // ���¸� ������ ������ ���·� �����Ѵ�.
        //    gState = GameState.GameOver;
        //}
    }
}
