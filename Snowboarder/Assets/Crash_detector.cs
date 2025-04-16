using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash_detector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float delayTime = 1.5f;
    [SerializeField] ParticleSystem crashEffect;

    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed) {
            hasCrashed = true;
            FindAnyObjectByType<Control>().DisableControl();
            Debug.Log("You have crashed!");
            GetComponent<AudioSource>().Play();
            crashEffect.Play();
            Invoke("ReloadScene", delayTime);
            
        }
    }

    private void ReloadScene(){
        SceneManager.LoadScene(1);
    }
}
