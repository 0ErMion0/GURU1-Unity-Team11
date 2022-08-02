using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // ȿ����
    //GameObject S2BackGroundMusic;
    //AudioSource backMusic;

    public AudioSource audioSource_jump;
    public AudioSource audioSource_collid;

    bool isJump = false;
    bool isTop = false;
    public float jumpHeight = 0;
    public float jumpSpeed = 0;
    public GameObject hitEffect;
    public GameObject[] heart;
    int count = 0;
    int heartN = 0;

    Vector2 startPosition;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;         //�÷��̾� �ʱ� ��ġ ����
        animator = GetComponent<Animator>();
        StartCoroutine(AddCount());

        // ȿ����
        audioSource_jump = GetComponent<AudioSource>();
        //audioSource_collid = GetComponent<AudioSource>();
    }

    public IEnumerator AddCount()
    {
        while (true)
        {
            count++;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count<43)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))             //���콺 ��Ŭ����
            {
                isJump = true;                          //isJump Ȱ��ȭ
                animator.SetTrigger("RunToJump");
                if (transform.position.y >= startPosition.y && transform.position.y <= -1.5) // �÷��̾� ��ġ >= �ʱ� ��ġ && �÷��̾� ��ġ <= Ư�� ��ġ ��
                {
                    audioSource_jump.Play(); // ȿ����
                }

            }
            else if (transform.position.y <= startPosition.y)      //�÷��̾� ��ġ�� �ʱ� ��ġ���� ���ų� >����< �� (�����ߴٰ� �ٽ� ���� ����� ��)
            {
                isJump = false;                                 //�ٽ� isJump�� isTop �������� ������ְ�
                isTop = false;
                transform.position = startPosition;             //�÷��̾� ��ġ �ʱ� ��ġ��
            }

            if (isJump)                                  //isJump�� ���� �� (Ȱ��ȭ �Ǿ��� �� = ���콺 ��Ŭ��)
            {
                //audioSource_jump.Play();// ȿ����

                if (transform.position.y <= jumpHeight - 0.1f && !isTop)        //���� ���̺��� �÷��̾� ��ġ�� ���� �� && �����(isTop)�� �ƴ� ��
                {
                    transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);       //����
                    //audioSource_jump.Play();// ȿ����

                }
                else
                {
                    isTop = true;
                }

                if (transform.position.y > startPosition.y && isTop)     //�÷��̾� ��ġ�� �ʱ� ��ġ���� Ŭ �� && �����(isTop)�� ��
                {
                    transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);    //�ʱ� ��ġ�� (�ٽ� ������)
                }

            }
        }
        else
        {
            animator.SetBool("Idle", true);

            if (transform.position.y > startPosition.y && isTop)     //�÷��̾� ��ġ�� �ʱ� ��ġ���� Ŭ �� && �����(isTop)�� ��
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);    //�ʱ� ��ġ�� (�ٽ� ������)
            }
        }

        if(heartN==3)
        {
            SceneManager.LoadScene("FailEnding3");          //�� ��ȯ

            ////S2BackGroundMusic
            //// 1. DontDestroy �� ������Ʈ ã��
            //S2BackGroundMusic = GameObject.Find("S2BackGroundMusic");

            //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
            //backMusic = S2BackGroundMusic.GetComponent<AudioSource>();

            //// 3. �׸��� �� ������ �����
            //backMusic.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Enemy_Fence(Clone)" || co.name == "Enemy_Sohwa(Clone)" || co.name == "Enemy_Kkokkal(Clone)" || co.name == "Enemy_Trash(Clone)")
        {
            audioSource_collid.Play(); // ȿ����
            StartCoroutine(PlayHitEffect());
            heart[heartN].SetActive(false);
            heartN++;

        }
    }

    IEnumerator PlayHitEffect()
    {
        //audioSource_collid.Play(); // ȿ����

        hitEffect.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        hitEffect.SetActive(false);
    }
}
