using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.Windows;
using StarterAssets;
using TMPro;

public class CameraManeger : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _input;
    [SerializeField] public Camera _mainCamera;
    private bool _isFPS;            // FPS���[�h
    private bool _isTPS;            // TPS���[�h

    public float _lookSpeedAdjust = 1.0f;   // ���x����

    [Header("Cinemachine")]
    [SerializeField] private CinemachineVirtualCamera _ThirdPersonCamera;
    [SerializeField] private CinemachineVirtualCamera _FirstPersonCamera;

    public bool _isClear;           // �N���A����
    public float distance = 6.0f;   // ���o�\�ȋ���
    public int filmlimit = 10;      // �ʐ^��������
    private int _useFilm = 0;       // �g�p�����t�B������
    public int _restFilm = 0;      // �c��t�B������
    private float _forceTime;       // �A�N�V�����C���^�[�o�����䎞��
    private bool _flagTime;         // �A�N�V�����s�C���^�[�o���t���O
    private bool _isHit;            // �B�e�Ώۂ̃I�u�W�F�N�g�ɔ��背�[�U�[���G��Ă��邩�ǂ���
    

    [Space(10)]
    [Tooltip("Shutter Flash Panel")]
    [SerializeField] public FlashAction _flashAction;

    [Space(10)]
    [Tooltip("Shutter Sound")]
    private AudioSource audioSource;
    public AudioClip _shutterSound; // �V���b�^�[��
    [Range(0, 1)] public float _shutterSoundVolume = 0.5f;

    
    public TextMeshProUGUI _textRestFilms;  // �c��t�B�������\��
    public GameObject _shutterButton;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        _ThirdPersonCamera.Priority = 10;
        _isTPS = true;
        _shutterButton.SetActive(false);

        _FirstPersonCamera.Priority = 0;
        _isFPS = false;
        _forceTime = 0.3f;

        _isClear = false;
    }

    private void Update()
    {
        // �C���^�[�o������
        if (_forceTime <= 0)
        {
            _flagTime = false;
        }
        _forceTime -= Time.deltaTime;

        // �t�B�����������v�Z
        CalcFilms();

        // FPS���_�̎��A�J�������画��p���[�U�[���Ǝ�
        if (_isFPS)
        {
            CheckTargetInCamera();
        }
        

    }

    /// <summary>
    /// �f�t�H���g��3�l�̎��_�ƃJ������1�l�̎��_�̐؂�ւ�
    /// </summary>
    public void CameraMode()
    {
        if (_isFPS)
        {
            // �O�l�̂ɐ؂�ւ���
            SetThirdPersonCamera();
        }
        else if (_isTPS) 
        {
            // ��l�̂ɐ؂�ւ���
            SetFirstPersonCamera();
        }

    }

    /// <summary>
    /// �c��t�B�������̌v�Z
    /// </summary>
    private void CalcFilms()
    {
        _restFilm = filmlimit - _useFilm;
        if (_restFilm > 0)
        {
            _textRestFilms.text = $"�t�B�����F{_restFilm}��";
            _textRestFilms.color = Color.green;
        }
        else if (_restFilm <= 0)
        {
            _textRestFilms.text = "EMPTY";
            _textRestFilms.color = Color.red;
        }
    }

    /// <summary>
    /// �O�l�̎��_
    /// </summary>
    private void SetThirdPersonCamera()
    {
        _ThirdPersonCamera.Priority = 10;
        _FirstPersonCamera.Priority = 0;
        _shutterButton.SetActive(false);
        _isFPS = false;
        _isTPS = true;
    }
    /// <summary>
    /// ��l�̎��_
    /// </summary>
    private void SetFirstPersonCamera() 
    {
        _ThirdPersonCamera.Priority = 0;
        _FirstPersonCamera.Priority = 10;
        _shutterButton.SetActive(true);
        _isFPS = true;
        _isTPS = false;
    }

    /// <summary>
    /// �J������1�l�̎��_���ɃV���b�^�[�������A�N�V����
    /// </summary>
    public void Shutter()
    {
        if (_isFPS && !_flagTime && _restFilm > 0)
        {
            // FPS���_�̂ݓK�p
            audioSource.PlayOneShot(_shutterSound);
            _flashAction.ShutterEffect();
            _useFilm++;
            _forceTime = 0.2f;
            _flagTime = true;

            if (_isHit)
            {
                _isClear = true;
                Debug.Log("�B�e�����I");
            }
            else
            {
                Debug.Log("�B�e���s");
            }
        }
    }

    /// <summary>
    /// �����Ă�������փf�o�b�O�p���[�U�[�𔭎˂��B�e�ΏۂɐG�ꂽ�ꍇ�A����Ƀ`�F�b�N����
    /// </summary>
    public void CheckTargetInCamera()
    {
        var rayStartPosition = _mainCamera.transform.position;
        var rayDirection = _mainCamera.transform.forward.normalized;
        RaycastHit raycastHit;
        var isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);
        // Debug.DrawRay (Vector3 start(ray���J�n����ʒu), Vector3 dir(ray�̕����ƒ���), Color color(���C���̐F));
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        if (isHit)
        {
            //���[�U�[���ΏۂɐG��Ă��邩�ǂ����̔���
            if (raycastHit.collider.CompareTag("Enemy"))
            {
                _isHit = true;
            }
            else
            {
                _isHit = false;
            }
        }

    }

    /// <summary>
    /// �J�����̊��x����
    /// </summary>
    public void CameraSenseAdjust()
    {
        _input.look *= _lookSpeedAdjust;
    }
}
