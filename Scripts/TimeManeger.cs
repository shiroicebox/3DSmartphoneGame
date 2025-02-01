using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class TimeManeger : MonoBehaviour
{
    public float Timelimit = 180.0f;        // ��������
    public TextMeshProUGUI _textTimelimit;  // �������Ԃ̃e�L�X�g�I�u�W�F�N�g

    public bool _isTimeUp;                  // �^�C���A�b�v�̃t���O

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �������Ԃ̃^�C�}�[&�������Ԕ���
        if (Timelimit > 0)
        {
            _isTimeUp = false;
            Timelimit -= Time.deltaTime;
        }
        else if (Timelimit <= 0)
        {
            _isTimeUp = true;
            Timelimit = 0;
        }

        // �e�L�X�g�̐���
        _textTimelimit.text = $"�������ԁF{Timelimit.ToString("#.#")}�b";
        if (Timelimit < 20.0f)
        {
            _textTimelimit.color = Color.red;
        }

    }
}
