using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTransitionStatus : MonoBehaviour
{
    public float waitTransition = 5.5f;
    
    private Animator _animator;
    private float _time;
    private bool _played;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _time = 0;
        _played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_time >= waitTransition && !_played)
        {
            _animator.SetTrigger("startTransition");
            _played = true;
        }
        else
        {
            _time += Time.deltaTime;
        }
    }
}
