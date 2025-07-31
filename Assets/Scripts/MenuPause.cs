using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public void retornar()
    {
        gameObject.SetActive(true);
    }

    public void Turorial ()
    {

    }

    public void sair()
    {
        Application.Quit();
        Debug.Log("Jogo encerrado.");
    }

}
