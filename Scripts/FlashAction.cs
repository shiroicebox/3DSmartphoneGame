using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashAction : MonoBehaviour
{
    private Image _img;
    // Start is called before the first frame update
    void Start()
    {
        // �t���b�V������
        _img = GetComponent<Image>();
        _img.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        // �t���b�V���̐���
        _img.color = Color.Lerp(_img.color, Color.clear, Time.deltaTime);
    }
    /// <summary>
    /// �V���b�^�[�̃t���b�V���̃G�t�F�N�g�𐧌�
    /// </summary>
    public void ShutterEffect()
    {
        _img.color = new Color(1, 1, 1, 1);
    }
}
