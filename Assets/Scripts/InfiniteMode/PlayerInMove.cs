using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInMove : MonoBehaviour
{
    // ȿ����
    public AudioSource audioSource_jump;
    public AudioSource audioSource_collid;

    //GameObject BackGroundMusicControl;
    //AudioSource backMusic;

    bool isJump = false;
    bool isTop = false;

    public float jumpHeight = 0;
    public float jumpSpeed = 0;

    public GameObject hitEffect;
    public GameObject[] heart;

    int heartN = 0;

    GameObject smObject;

    Vector2 startPosition;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;         //�÷��̾� �ʱ� ��ġ ����

        animator = GetComponent<Animator>();

        smObject = GameObject.Find("MenuManager");

        // ȿ����
        audioSource_jump = GetComponent<AudioSource>();
        //audioSource_collid = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MainMenuManager sm = smObject.GetComponent<MainMenuManager>();

        if (sm.play)
        {
            animator.speed = 1.0f;           //�ִϸ��̼� ����

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
                
                if (transform.position.y <= jumpHeight - 0.1f && !isTop)        //���� ���̺��� �÷��̾� ��ġ�� ���� �� && �����(isTop)�� �ƴ� ��
                {
                    transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);       //����
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

            if (heartN == 5)           //��� �ټ� �� �� ���̸�
            {
                SceneManager.LoadScene("InfiniteModeGameOver");          //�� ��ȯ

                //// 1. DontDestroy �� ������Ʈ ã��
                //BackGroundMusicControl = GameObject.Find("BackGroundMusicControl");

                //// 2. �� �ȿ� ���Ե� AudioSource ������ �ִ´�
                //backMusic = BackGroundMusicControl.GetComponent<AudioSource>();

                //// 3. �׸��� �� ������ �����
                //backMusic.Stop();
            }
        }
        else
        {
            animator.speed = 0.0f;           //�ִϸ��̼� ��Ȱ��ȭ
        }
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Enemy_Books(Clone)" || co.name == "Enemy_Chair(Clone)" || co.name == "Enemy_Clothes(Clone)" || co.name == "Enemy_Fan(Clone)" || co.name == "Enemy_Fence(Clone)" || co.name == "Enemy_Sohwa(Clone)" || co.name == "Enemy_Kkokkal(Clone)" || co.name == "Enemy_Trash(Clone)" || co.name == "Enemy_Cat1(Clone)" || co.name == "Enemy_Cat2(Clone)" || co.name == "Enemy_Cat3(Clone)" || co.name == "Enemy_Flowerpot(Clone)")
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
