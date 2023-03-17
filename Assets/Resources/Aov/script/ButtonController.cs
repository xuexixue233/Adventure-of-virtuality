
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public GameObject[] ButtonPrefabs;
    private GameObject[] ButtonGameObjects;
    private int selectedIndex = 0;
    private int length;//���пɹ�ѡ���ɫ�ĸ�����
    private PlayerInputActions controls;
    private Vector2 move;

    void Awake()
    {
        controls = new PlayerInputActions();
        controls.GamePlay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GamePlay.Move.canceled += ctx => move = Vector2.zero;

    }
    void OnEnable()
    {
        controls.GamePlay.Enable();
    }
    void OnDisable()
    {
        controls.GamePlay.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        length = ButtonPrefabs.Length;
        ButtonGameObjects = new GameObject[length];
        for (int i = 0; i < length; i++)
        {
            ButtonGameObjects[i] = GameObject.Instantiate(ButtonPrefabs[i], transform.position, transform.rotation) as GameObject;
        }
        UpdateCharacterShow();
    }

    void Update()
    {
        if (move.y < 0)
        {
            OnPrevButtonClick();
        }else if (move.y > 0)
        {
            OnNextButtonClick();
        }
    }

    void UpdateCharacterShow()
    {//�������н�ɫ��
        ButtonGameObjects[selectedIndex].GetComponent<UnityEngine.UI.Button>().Select();
    }

    public void OnNextButtonClick()
    {//�����ǵ������һ����ť��
        selectedIndex++;
        selectedIndex %= length;
        UpdateCharacterShow();
    }

    public void OnPrevButtonClick()
    {//�����ǵ������һ����ť��
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length - 1;
        }
        UpdateCharacterShow();
    }
}