using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoatAnimation : MonoBehaviour
{
    [Header("Play Animation when boss is destroyed")]
    [SerializeField] private Animator anim;
    [SerializeField] private string sailBoat = "SailBoat";

    public GameObject levelCompleted;

    // Start is called before the first frame update
    void Start()
    {
        levelCompleted.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("AnimationPlaying");
            anim.Play(sailBoat, 0, 0.0f);
            levelCompleted.SetActive(true);
            StartCoroutine(LoadTextChangeScene());
        }    
    }

    IEnumerator LoadTextChangeScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameCompleted");
        Cursor.visible = true;
        Screen.lockCursor = false;
    }
}
