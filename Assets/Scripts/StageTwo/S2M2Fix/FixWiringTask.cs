using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ����Ǿ�� �ϴ� ���� �� ǥ�� �迭
public enum EWireColor
{
    // ����Ƽ���� �����ϴ� ����11����: Black, Blue, Cyan, Gray, Green, Magenta, Red, White, Yellow, Clear
    None = -1,
    Magenta,//Pink,
    Blue,
    Yellow,
    Gray //Brown
}

public class FixWiringTask : MonoBehaviour
{
    [SerializeField]
    private List<LeftWire> mLeftWires;

    [SerializeField]
    private List<RightWire> mRightWires;

    // ���� ���õ� ���̾� ��� ���� ����
    private LeftWire mSelectedWire;

    private void OnEnable()
    {
        List<int> numberPool = new List<int>();

        // Left
        for(int i = 0; i < 4; i++)
        {
            numberPool.Add(i);
        }

        int index = 0;
        while(numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            mLeftWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }

        // Right
        for (int i = 0; i < 4; i++)
        {
            numberPool.Add(i);
        }

        index = 0;
        while (numberPool.Count != 0)
        {
            var number = numberPool[Random.Range(0, numberPool.Count)];
            mRightWires[index++].SetWireColor((EWireColor)number);
            numberPool.Remove(number);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // ���� ���°� ������ �ߡ� ������ ���� ������ �� �ְ� �Ѵ�.
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }

        
         // ���콺 ��ư ������ ���� Raycast�� ���� ���� �ݶ��̴��� �θ𿡼� (up)leftwire�� ã�Ƽ�
         // mSelectedWire�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);

            if (hit.collider != null)
            {
                var left = hit.collider.GetComponentInParent<LeftWire>();
                if (left != null)
                {
                    mSelectedWire = left;
                }
            }
        }

        // ���콺 Ŭ���� ���� ����
        // mWireBody�� ����, �Ÿ� ���� ���� and mSelectedWire ����ֱ�
        if (Input.GetMouseButtonUp(0))
        {
            // 
            if (mSelectedWire != null)
            {
                // Ŭ�� ���� ���� �����ɽ��� �߻��ϰ� rightwire ã����
                RaycastHit2D[] hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);
                foreach (var hit in hits)
                {
                    if (hit.collider != null)
                    {
                        var right = hit.collider.GetComponentInParent<RightWire>();
                        if (right != null)
                        {
                            mSelectedWire.SetTarget(hit.transform.position, 50f);
                            mSelectedWire.ConnectWire(right);
                            right.ConnectWire(mSelectedWire);

                            mSelectedWire = null;
                            CheckCompleteTask(); // ���̾ �������� �������Ǵ� �������� �˻��ϵ��� update�ȿ�
                            return;
                        }
                    }
                }

                mSelectedWire.ResetTarget();
                mSelectedWire.DisconnectWire();
                //mWireBody.localRotation = Quaternion.Euler(Vector3.zero);
                //mWireBody.sizeDelta = new Vector2(0f, mWireBody.sizeDelta.y); 
                mSelectedWire = null;
                CheckCompleteTask();
            }
        }


        // mSelectedWire�� ������� ���� ���ȿ��� ������Ʈ�� ��ġ�� ���콺 Ŀ���� ��ġ�� �̿��ؼ�
        // ������ ������ ������ �Ÿ� ��� �� WireBody�� �����ϵ��� 
        if (mSelectedWire != null)
        {
            mSelectedWire.SetTarget(Input.mousePosition, 30f);
        }
    }

    private void CheckCompleteTask()
    {
        bool isAllComplete = true;
        foreach (var wire in mLeftWires)
        {
            if(!wire.IsConnected)
            {
                isAllComplete = false;
                break;
            }
        }

        if(isAllComplete)
        {
            SceneManager.LoadScene("FailEnding5");
        }
    }
}
