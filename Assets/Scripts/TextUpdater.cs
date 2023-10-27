using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] TMP_Text screenText;
    [SerializeField] Animator animText;
    [SerializeField] string[] tutorialText = new string[10];
    // Start is called before the first frame update
    void Start()
    {
        screenText = GetComponent<TMP_Text>();
        animText = GetComponent<Animator>();
        tutorialText[1] = "<color=\"white\">-  Para movimentar-se, configure o <color=\"red\">1º SWITCH<color=\"white\">para<color=\"red\">MOVE.\r\n<color=\"white\">- Use as <color=\"red\">SETAS DE MOVIMENTAÇÃO <color=\"white\">para mover-se.\r\n<color=\"white\">- Siga em frente com a <color=\"red\">SETA DE CIMA.";
        tutorialText[2] = "<color=\"white\">- Cada movimento é <color=\"yellow\">1 turno.\r\n<color=\"white\">- Em cada turno, inimigos se movem e o cenário é alterado.\r\n<color=\"white\">- Quanto mais próximo o objeto, mais nítida é sua aparência.\r\n<color=\"white\">- Siga em frente para continuar.";
        tutorialText[3] = "<color=\"white\">- Mude o campo de visão girando a <color=\"red\">ROLETA.\r\n<color=\"white\">- Para confirmar, clique em <color=\"red\">SEND →.\r\n<color=\"white\">- Ao confirmar, <color=\"yellow\">1 turno <color=\"white\">é gasto.\r\n<color=\"white\">- Mude a visão para a direita e progrida.";
        tutorialText[4] = "- <color=\"yellow\">Obstáculos <color=\"white\">no ambiente sempre permanecem <color=\"yellow\">imóveis.\r\n<color=\"white\">- Obstáculos de <color=\"yellow\">1 quadrado <color=\"white\">são pedras ou detritos.\r\n<color=\"white\">- Obstáculos de <color=\"yellow\">2 quadrados em diagonal <color=\"white\">são parte da vegetação.\r\n- <color=\"yellow\">Obstáculos maiores <color=\"white\">não possuem padrões, mas alteram a navegação.\r\n<color=\"white\">- Use obstáculos para <color=\"yellow\">guiar-se pelo ambiente.\r\n<color=\"white\">- Contorne o obstáculo maior para prosseguir.";
        tutorialText[5] = "<color=\"white\">- Missões exigem a coleta de um item no cenário.\r\n<color=\"white\">- Para coletar, configure o <color=\"red\">1º SWITCH <color=\"white\">para <color=\"red\">CURSOR.\r\n<color=\"white\">- Depois, veja se o <color=\"red\">2º SWITCH <color=\"white\">está em <color=\"red\">USE.\r\n<color=\"white\">- Use as <color=\"red\">SETAS DE MOVIMENTAÇÃO <color=\"white\">para mirar e selecionar o item.\r\n<color=\"white\">- Note que há um alcance máximo na mira.\r\n<color=\"white\">- Acione o <color=\"red\">BOTÃO VERMELHO <color=\"white\">para confirmar.\r\n<color=\"white\">- Usar o <color=\"red\">CURSOR <color=\"white\">impede a locomoção. \r\n<color=\"white\">- Configure o <color=\"red\">1º SWITCH <color=\"white\">para <color=\"red\">MOVE <color=\"white\">e prossiga.";
        tutorialText[6] = "<color=\"white\">- Áreas mais escuras são corpos de água no ambiente.\r\n<color=\"white\">- Não é possível acessar tais áreas, então mude sua rota.";
        tutorialText[7] = "<color=\"white\">- O <color=\"red\">CONTADOR DE MUNIÇÃO <color=\"white\">indica as balas na arma do mecha.\r\n<color=\"white\">- Colete munições de mechas destruídos.\r\n<color=\"white\">- Configure os <color=\"red\">SWITCHS <color=\"white\">para <color=\"red\">USE <color=\"white\">e <color=\"red\">CURSOR.\r\n<color=\"white\">- Utilize o <color=\"red\">BOTÃO VERMELHO <color=\"white\">para confirmar.";
        tutorialText[8] = "<color=\"white\">- Durante as missões, <color=\"yellow\">ameaças <color=\"white\">surgirão.\r\n<color=\"white\">- Quando próximas, a <color=\"red\">LUZ DE AVISO <color=\"white\">ficará amarela e emitirá um som.\r\n<color=\"white\">- Ameaças tendem a se movimentar. Use isto a seu favor.\r\n<color=\"white\">- Para atirar, configure o <color=\"red\">1º SWITCH <color=\"white\">para <color=\"red\">CURSOR.\r\n<color=\"white\">- Depois, configure o <color=\"red\">2º SWITCH <color=\"white\">para <color=\"red\">GUN.\r\n<color=\"white\">- Use as <color=\"red\">SETAS DE MOVIMENTAÇÃO <color=\"white\">para mirar e selecionar o alvo.\r\n<color=\"white\">- Note que há um alcance máximo na mira.\r\n<color=\"white\">- Acione o <color=\"red\">BOTÃO VERMELHO <color=\"white\">para confirmar o tiro.\r\n<color=\"white\">- Atirar custa <color=\"yellow\">1 de munição e <color=\"yellow\">1 turno.";
        tutorialText[9] = "<color=\"white\">- Neste treinamento, ameaças foram substituídas por alvos holográficos.\r\n<color=\"white\">- Em uma missão, prepare-se para perseguições que danificarão o mecha.\r\n<color=\"white\">- Treinamento concluído, piloto, avance para o ponto de extração. O desconhecido espera os corajosos!";
        screenText.text = tutorialText[0];
    }
    public void SetTutorialText(int stage)
    {
        screenText.text = tutorialText[stage];
        animText.Play("TextFlash");
    }
    public void SendTextMessage(string msg)
    {
        screenText.text = msg;
        animText.Play("TextFlash");
    }
}
