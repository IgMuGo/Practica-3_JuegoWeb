using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool gameStarting = false;
    [SerializeField] Animator shipAnimator;
    Animator canvasAnimator;
    [SerializeField] MusicFades musicPlayer;

    private void Awake()
    {
        canvasAnimator=GetComponent<Animator>();   
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (!gameStarting)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartGameSequence();
                gameStarting = true;
            }
        }
    }

    void StartGameSequence()
    {
        canvasAnimator.Play("StartGame");
        shipAnimator.Play("Start");
        musicPlayer.SetFade(5,0);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
