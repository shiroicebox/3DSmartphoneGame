using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class EnemyControler : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;

    //private float _speed = 2.0f;

    private float _animationBlend;
    // animation IDs
    private int _animIDSpeed;
    private int _animIDMotionSpeed;

    private Animator _animator;
    private bool _hasAnimator;

    //[Tooltip("AudioClip")]
    //public AudioClip LandingAudioClip;
    //public AudioClip[] FootstepAudioClips;
    //[Range(0, 1)] public float FootstepAudioVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //_hasAnimator = TryGetComponent(out _animator);
        //AssignAnimationIDs();
    }

    // Update is called once per frame
    void Update()
    {
        //_hasAnimator = TryGetComponent(out _animator);

        EnemyMove();
    }

    private void EnemyMove()
    {
        if (target.GetComponent<ThirdPersonController>()._isArea == true)
        {
            agent.destination = target.transform.position;
        }

        //float targetSpeed = _speed;
        //float inputMagnitude = 1f;
        //_animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime);
        //if (_animationBlend < 0.01f) _animationBlend = 0f;

        //// update animator if using character
        //if (_hasAnimator)
        //{
        //    _animator.SetFloat(_animIDSpeed, _animationBlend);
        //    _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
        //}
    }

    ///// <summary>
    ///// アニメーションIDを呼び出す
    ///// </summary>
    //private void AssignAnimationIDs()
    //{
    //    _animIDSpeed = Animator.StringToHash("Speed");
    //    _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    //}
}
