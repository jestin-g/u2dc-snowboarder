using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float _timeBeforeReload = 0.5f;
    [SerializeField] private ParticleSystem _crashEffect;
    [SerializeField] private AudioClip _crashSfx;
    private bool _isTriggered = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Level" && !_isTriggered)
        {
            _isTriggered = true;
            Loose();

        }
    }

    private void Loose()
    {
        Debug.Log("BONK!");
        FindObjectOfType<PlayerController>().DisableControls();
        GetComponent<AudioSource>().PlayOneShot(_crashSfx);
        _crashEffect.Play();
        Invoke("ReloadScene", _timeBeforeReload);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
