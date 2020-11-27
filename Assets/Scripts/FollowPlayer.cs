using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    public GameObject target;

    private Rigidbody _player;
    private Vector3 _offset;
    private Animator _animator;
    private bool _endAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _player = target.GetComponent<Rigidbody>();
        _offset = transform.position - target.transform.position;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator.enabled)
        {
            _player.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            _player.constraints = RigidbodyConstraints.None;
        }
        
        if (!target.Equals(null))
        {
            transform.position = target.transform.position + _offset;
        }
    }

    public void endAnimation()
    {
        _animator.enabled = false;
    }

}
