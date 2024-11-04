using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

public class GameController : MonoBehaviour
{

    public Text Placar;
    public GameObject Pause;
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(UnityEngine.Input.GetKeyDown(KeyCode.P)){
            if(Time.timeScale == 0f){
                Time.timeScale = 1f;
                Pause.SetActive(false);
                Placar.IsActive();
                AudioSource musica = Camera.GetComponent<AudioSource>();
                musica.Play();
            }
            else{
                Time.timeScale = 0f;
                Pause.SetActive(true);
                Placar.IsActive();
                AudioSource musica = Camera.GetComponent<AudioSource>();
                musica.Pause();
            }  
        }
        
    }

    public void Continuar()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
        Placar.IsActive();
        AudioSource musica = Camera.GetComponent<AudioSource>();
        musica.Play();
    }

    public void ReiniciarJogo()
    {
        Scene cena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cena.name);
    }

     public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }
}
