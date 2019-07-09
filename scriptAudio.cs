using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAudio : MonoBehaviour
{





    public float speed=1;
    public AudioSource fonteSom;
    private float timer;
    private float seconds;
    // Start is called before the first frame update
    //Controlador de audio
    void Start()
    {
        

    }

    
    public void audioControlador( AudioClip musica)
    {
        Debug.Log("abrindo musica");
        fonteSom.volume = 1;
        timer = 0;
        fonteSom.clip = musica;
        fonteSom.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        seconds = timer  % 60;
        if (fonteSom.volume > 0)
        {
            fonteSom.volume = 1 * ((14 - seconds) / 14);
            
        }
        

    }
}
