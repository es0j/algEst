using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class coletor2 : MonoBehaviour
{
    // Start is called before the first frame update

    //todas as musicas do jogo. eu deveria fazer isso em uma lista, mas nao sei fazer ops..
    public AudioClip agressive1;
    public AudioClip agressive2;
    public AudioClip atm1;
    public AudioClip atm2;
    public AudioClip metallicb1;
    public AudioClip metallicb2;
    public AudioClip piano;
    public AudioClip dead;
    public AudioClip pressure;
    public scriptAudio meuAudio;



    //objetos para serem alterados ao ocorrer colisao
    public GameObject porta1Abrir;
    public GameObject inimigo;
    public GameObject posProcess;
    public GameObject luzPlayer;

    //caixas de texto
    public Text contadorTexto;
    public Text Lore;
    public Text vidaUI;

    private int contagem = 0;
    private float vida = 100;
    public float dificuldade = 1.0f;


    public PostProcessVolume volume;
    ChromaticAberration aberracaoCromatica;
    Vignette vignatte;

    private Vector3 ultimoCheck;

    void Start()
    {
        
        contadorTexto.text = "Chaves Recolhidas "+ contagem.ToString();
        Lore.text = "";
        //pos processamento
        volume.profile.TryGetSettings(out aberracaoCromatica);
        volume.profile.TryGetSettings(out vignatte);
    }

    // Update is called once per frame
    void Update()
    {
        //checa o dano
        Vector3 distancia= inimigo.transform.position - transform.position;
        vida = vida - contagem*(dificuldade / distancia.magnitude)* (dificuldade / distancia.magnitude)*Time.deltaTime;
        vidaUI.text = "vida : " + vida.ToString();
        if (vida<0)
        {
            SceneManager.LoadScene("fimRuim");
        }


        //brincadeiras com pos processamento a medida q vc chega perto do monstro
        if (distancia.magnitude <10 && aberracaoCromatica.intensity.value<4)
        {
            aberracaoCromatica.intensity.value += (dificuldade / distancia.magnitude) * Time.deltaTime;
        }
        if (distancia.magnitude > 10 && aberracaoCromatica.intensity.value > 0.4)
        {
            aberracaoCromatica.intensity.value -= 0.05f * (dificuldade / distancia.magnitude)* Time.deltaTime;
        }

        //o bendito sangue na tela entra aqui.
        if (distancia.magnitude < 10 && vignatte.intensity.value < 0.5)
        {
            vignatte.intensity.value += 0.3f*(dificuldade / distancia.magnitude) * Time.deltaTime;
        }
        if (distancia.magnitude > 10 && vignatte.intensity.value > 0)
        {
            vignatte.intensity.value -= 0.2f * (dificuldade / distancia.magnitude) * Time.deltaTime;
        }


    }
    void OnTriggerEnter(Collider outroObjeto)
    {
        
        if (outroObjeto.gameObject.CompareTag("coletavel"))
        {
            
            outroObjeto.gameObject.SetActive(false);
            contagem++;
            contadorTexto.text = "Chaves Recolhidas " + contagem.ToString();

            
            switch (contagem)
            {
                //dispara o dialogo equivalente ao numero de chaves
                case 1:
                    meuAudio.audioControlador(atm1);
                    inimigo.GetComponent<NavMeshAgent>().speed = 1;
                    Lore.text = "";
                    break;
                case 2:
                    meuAudio.audioControlador(atm2);
                    porta1Abrir.SetActive(false);
                    Lore.text = "Aqueles que estiveram expostos à aberração reportaram desde incessantes dores de cabeça até as mais terríveis aluncinações.";
                    break;
                case 3:
                    meuAudio.audioControlador(metallicb1);
                    Lore.text = "A porta de saída está trancada a 7 chaves.";
                    break;
                case 4:
                    meuAudio.audioControlador(metallicb2);
                    Lore.text = "O passa tempo preferido dele é vigiar...";
                    break;
                case 5:
                    meuAudio.audioControlador(agressive2);
                    Lore.text = "O homem sem rosto vive nas florestas...";
                    break;
                case 6:
                    meuAudio.audioControlador(agressive1);
                    Lore.text = "E também em seus piores pesadelos...";
                    break;
                case 7:
                    meuAudio.audioControlador(pressure);
                    Lore.text = "CAN'T RUN.";
                    break;
                    
            }
            
        }
        if (outroObjeto.gameObject.CompareTag("lanterna"))
        {
            //obeteve a lanterna. Ativa a lanterna e dispara o primeiro diálogo
            outroObjeto.gameObject.SetActive(false);
            Lore.text = "Ele é um homem magro, anormalmente alto. Nas lendas mais terríveis ele era aquele que abduzia e traumatizava as crianças que se perdiam pelas florestas. O perseguidor. Tente não olhar para ele...";
            luzPlayer.SetActive(true);
        }
        if (outroObjeto.gameObject.CompareTag("FIM"))
        {
            if (contagem==7)
            {
                //fim de jogo. Carrega o final bom
                Lore.text = "Você Escapou!";
                inimigo.SetActive(false);
                SceneManager.LoadScene("fimBom");
            }
            
            
        }

        if (outroObjeto.gameObject.CompareTag("checkPoint"))
        {
            //checa se o player passou por um checkpoint e invoca o teleporte do monstro
            ultimoCheck = outroObjeto.gameObject.transform.position;
            Invoke("mudarPos", 2.5f);
        }

    }
    void mudarPos()
    {
        //Teleporta o monstro apos o jogador passar por um checkpoint
        inimigo.transform.position = ultimoCheck;
    }
}
