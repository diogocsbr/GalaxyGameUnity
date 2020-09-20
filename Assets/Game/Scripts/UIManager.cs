using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Sprite[] vidas;
    public Image imagemVida;

    public Text PontosTexto;

    public int Pontos;

    public GameObject titleScreen;

    public void AtualizarVidas(int vidaCorrente) 
    {
        imagemVida.sprite = vidas[vidaCorrente];    
    }

    public void AtualizarScore() 
    {
        Pontos += 10;
        PontosTexto.text = $"Pontos:{Pontos}";
    }

    public void MostrarTelaInicial() 
    {
        titleScreen.SetActive(true);
    }
    public void EsconderTelaInicial()
    {
        titleScreen.SetActive(false);

        Pontos += 0;
        PontosTexto.text = $"Pontos:";
    }
}
