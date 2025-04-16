using UnityEngine;
using UnityEngine.SceneManagement;

public class End_line : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float delayTime = 1.5f;
    [SerializeField] ParticleSystem finishEffect;

    bool hasWon = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !hasWon) {
            hasWon = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Debug.Log("Stage finished!");
            Invoke("ReloadScene", delayTime);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(1);
    }
}
