using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool gameStarting = false;
    [SerializeField] Animator shipAnimator;     //Referencia al animator de la nave
    Animator canvasAnimator;                    //Referencia al animator del canvas
    [SerializeField] MusicFades musicPlayer;    //Referencia al AudioSource que reproduce la m�sica

    private void Awake()
    {
        canvasAnimator=GetComponent<Animator>();   
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Pulsar espacio para comenzar l�a secuencia de inicio de juego si a�n no se ha iniciado
        if (!gameStarting)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartGameSequence();
                gameStarting = true;
            }
        }
    }

    //Secuencia de inicio de juego
    void StartGameSequence()
    {
        canvasAnimator.Play("StartGame");   //Llama a la animaci�n del canvas para iniciar el juego
        shipAnimator.Play("Start");         //Llama a la animaci�n que realiza la nave al iniciar el juego
        musicPlayer.SetFade(5,0);           //Aplica un FadeOut en el reproductor de m�sica
    }

    //Funci�n para cargar la escena de juego. Esta funci�n es llamada desde un evento en la animaci�n del canvas
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
