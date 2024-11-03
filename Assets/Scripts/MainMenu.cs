using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool gameStarting = false;
    [SerializeField] Animator shipAnimator;     //Referencia al animator de la nave
    Animator canvasAnimator;                    //Referencia al animator del canvas
    [SerializeField] MusicFades musicPlayer;    //Referencia al AudioSource que reproduce la música

    private void Awake()
    {
        canvasAnimator=GetComponent<Animator>();   
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Pulsar espacio para comenzar lña secuencia de inicio de juego si aún no se ha iniciado
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
        canvasAnimator.Play("StartGame");   //Llama a la animación del canvas para iniciar el juego
        shipAnimator.Play("Start");         //Llama a la animación que realiza la nave al iniciar el juego
        musicPlayer.SetFade(5,0);           //Aplica un FadeOut en el reproductor de música
    }

    //Función para cargar la escena de juego. Esta función es llamada desde un evento en la animación del canvas
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
