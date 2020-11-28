using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject target;

    private Rigidbody _player;
    private Vector3 _offset;
    private Animator _animator;
    private Transform _statusGame;

    // Start is called before the first frame update
    void Start()
    {
        _player = target.GetComponent<Rigidbody>();
        _player.constraints = RigidbodyConstraints.FreezeAll;
        _offset = transform.position - target.transform.position;
        _animator = GetComponent<Animator>();
        _statusGame = GameObject.Find("Canvas").transform.Find("GameStatus");
    }

    // Update is called once per frame
    void Update()
    {
        if (!target.Equals(null))
        {
            transform.position = target.transform.position + _offset;
        }
    }

    public void endAnimation()
    {
        _animator.enabled = false;
        _player.constraints = RigidbodyConstraints.None;
        _statusGame.gameObject.SetActive(true);
    }

    public bool isAnimationEnd()
    {
        return !_animator.enabled;
    }

}
