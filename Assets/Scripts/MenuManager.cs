using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    
    public Canvas canvasMenu;
    public Image painelFade;
    public float duracaoFade = 1.5f;
    public GameObject sistemaDeJogo;
    private void Start()
    {
        
        if (painelFade != null)
        {
            painelFade.color = new Color(0, 0, 0, 0);
        }

        
        if (sistemaDeJogo != null)
        {
            sistemaDeJogo.SetActive(false);
        }
    }

    public void Jogar()
    {
        StartCoroutine(FadeOutMenu());
    }

    IEnumerator FadeOutMenu()
    {
        float tempo = 0f;
        Color corInicial = painelFade.color;
        Color corFinal = new Color(0, 0, 0, 1); 

        while (tempo < duracaoFade)
        {
            tempo += Time.deltaTime;
            painelFade.color = Color.Lerp(corInicial, corFinal, tempo / duracaoFade);
            yield return null;
        }

        // Desativa o menu
        canvasMenu.gameObject.SetActive(false);

        // Ativa o jogo
        if (sistemaDeJogo != null)
        {
            sistemaDeJogo.SetActive(true);
        }
    }

    public void Tutorial()
    {
        Debug.Log("Tela de tutorial ainda não implementada.");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
