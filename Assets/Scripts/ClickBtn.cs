using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickBtn : MonoBehaviour
{

    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        _audioSource.Play();
        SceneManager.LoadScene("Level1");
    }
    
    public void backMenu()
    {
        _audioSource.Play();
        SceneManager.LoadScene("StartMenu");
    }
    
}
