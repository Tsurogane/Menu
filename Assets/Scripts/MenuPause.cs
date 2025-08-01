using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuPause : MonoBehaviour
{

    public Canvas canvasMenu;
    public Image painelFade;
    public float duracaoFade = 1.5f;
    public GameObject sistemaDeJogo;


    public Canvas canvasPause;

    private bool jogoPausado = false;

    private void Start()
    {
        if (painelFade != null)
            painelFade.color = new Color(0, 0, 0, 0);

        if (sistemaDeJogo != null)
            sistemaDeJogo.SetActive(false);

        if (canvasPause != null)
            canvasPause.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && sistemaDeJogo.activeSelf)
        {
            if (!jogoPausado)
                AtivarPause();
            else
                DesativarPause();
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

        canvasMenu.gameObject.SetActive(false);
        if (sistemaDeJogo != null)
            sistemaDeJogo.SetActive(true);
    }


    public void AtivarPause()
    {
        Time.timeScale = 0f;
        canvasPause.gameObject.SetActive(true);
        jogoPausado = true;
    }

    public void DesativarPause()
    {
        Time.timeScale = 1f;
        canvasPause.gameObject.SetActive(false);
        jogoPausado = false;
    }

    public void SairDoPause()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Tutorial()
    {
        Debug.Log("Tutorial ainda não implementado.");
    }

    public void Sair()
    {
        Application.Quit();
    }
}


