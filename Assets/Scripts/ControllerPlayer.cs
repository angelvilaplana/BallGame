using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerPlayer : MonoBehaviour
{
    public Vector3 restartPosition;
    public float deadPositionY;
    public AudioSource backgroundSong;
    public TextMeshProUGUI golText;
    public ParticleSystem golParticles;
    public AudioClip audioJump;
    public AudioClip audioDie;
    public AudioClip audioGol;
    public Animator canvasAnimation;
    public CameraController camera;

    public float forceValue;
    public float jumpValue;
    private Rigidbody _rb;
    private AudioSource _audioSource;
    private bool _isGrounded;
    private bool _isInGoal;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _isInGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (camera.isAnimationEnd() && !_isInGoal)
        {
            GameStatusManager.timePlayed += Time.deltaTime;

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                kick();
            }

            if (Input.acceleration.z > 0.1 && _isGrounded)
            {
                kick();
            }

            if (Input.touchCount == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began && _isGrounded)
                {
                    kick();
                }
            }

            if (transform.position.y <= deadPositionY)
            {
                die();
            }
        }
        
        if (_isInGoal && _audioSource.volume == 0)
        {
            StartCoroutine(changeScene());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            _isInGoal = true;
            StartCoroutine(animationGol());
            backgroundSong.Stop();
            _audioSource.clip = audioGol;
            _audioSource.Play();
            golParticles.Play();
        }
    }

    private IEnumerator animationGol()
    {
        golText.transform.localScale = new Vector3(1, 0, 1);
        golText.text = "GOL";

        while (golText.transform.localScale.y < 1)
        {
            if (golText.text.Length == 6)
            {
                golText.text = "GOL";
            }
            else
            {
                golText.text += "!";
            }
            golText.transform.localScale += new Vector3(0, .01f, 0);
            yield return null;
        }

        var numberOfTimes = 0;
        while (true)
        {
            if (golText.text.Length == 6)
            {
                golText.text = "GOL";
            }
            else
            {
                golText.text += "!";
            }

            if (numberOfTimes == 10)
            {
                canvasAnimation.SetTrigger("End");
                StartCoroutine(endVolume());
                numberOfTimes++;
            }
            else
            {
                numberOfTimes++;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
    
    private IEnumerator endVolume()
    {
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= 0.01f;
            yield return null;
        }
    }

    private IEnumerator changeScene()
    {
        yield return new WaitForSeconds(1);
        var scene = SceneManager.GetActiveScene();
        var numNextLevel = Convert.ToInt32(scene.name.Substring(5)) + 1;
        var nextLevel = "Level" + numNextLevel;
        if (Application.CanStreamedLevelBeLoaded(nextLevel))
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    void OnCollisionStay(Collision other)
    {
        _isGrounded = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            die();
        }
    }

    private void die()
    {
        _audioSource.clip = audioDie;
        _audioSource.Play();
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero; 
        transform.localPosition = restartPosition;
        transform.rotation = Quaternion.identity;
        GameStatusManager.deaths++;
    }

    private void kick()
    {
        _rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
        _audioSource.clip = audioJump;
        _audioSource.Play();
        _isGrounded = false;
        GameStatusManager.kicks++;
    }

    private void FixedUpdate()
    {
        if (!_isInGoal)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            _rb.AddForce(new Vector3(h, 0, v) * forceValue);
        
            h = Input.acceleration.x;
            v = Input.acceleration.y;
            _rb.AddForce(new Vector3(h * 1.2f, 0, v * 1.2f) * forceValue);
        }
    }
}
