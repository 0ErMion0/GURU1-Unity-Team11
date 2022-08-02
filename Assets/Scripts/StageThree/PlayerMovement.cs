using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // ȿ����
    //GameObject S3BackGroundMusic;
    //AudioSource backMusic;
    AudioSource audioSource;

    public float speed = 0.5f;
    Rigidbody2D rigid2D;

    public GameObject hitEffect;

    public GameObject[] heart;
    int heartN = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        // ȿ����
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");       //�¿� �̵�
        float y = Input.GetAxisRaw("Vertical");         //���Ʒ� �̵�

        rigid2D.velocity = new Vector3(x, y, 0) * speed;

        if (heartN == 3)                                //��� �� ���̸� ���� ������
        {
            SceneManager.LoadScene("FailEnding6");

            ////S3BackGroundMusic
            //// 1. DontDestroy �� ������Ʈ ã��
            //S3BackGroundMusic = GameObject.Find("S3BackGroundMusic");

            //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
            //backMusic = S3BackGroundMusic.GetComponent<AudioSource>();

            //// 3. �׸��� �� ������ �����
            //backMusic.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D co)            //��ġ || �쵿 || ���� �� �ϳ� ������ ����
    {
        if (co.name == "Uchi" || co.name == "Udong" || co.name == "RangE")
        {
            audioSource.Play(); // ȿ����
            StartCoroutine(PlayHitEffect());
            heart[heartN].SetActive(false);
            heartN++;
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        hitEffect.SetActive(false);
    }
}
