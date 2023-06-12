using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private static float s_timeBeforeReload = 1f;
    [SerializeField] private ParticleSystem _finishEffect;
    private bool _isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isTriggered) return;
        _isTriggered = true;
        if (other.tag == "Player")
            Win();
    }

    private void Win()
    {
        Debug.Log("GG!");
        GetComponent<AudioSource>().Play();
        _finishEffect.Play();
        Invoke("ReloadScene", s_timeBeforeReload);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
