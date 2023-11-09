using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] TMP_Text screenText;
    [SerializeField] Animator animText;
    [SerializeField] string[] tutorialText = new string[13];
    // Start is called before the first frame update
    void Start()
    {
        screenText = GetComponent<TMP_Text>();
        animText = GetComponent<Animator>();
        tutorialText[1] = "<color=\"white\">-  Para movimentar-se, veja se o <color=\"red\">1º SWITCH<color=\"white\"> está em <color=\"red\">MOVE.\r\n\r\n<color=\"white\">- Depois, use as <color=\"red\">SETAS DE MOVIMENTAÇÃO.";
        tutorialText[2] = "<color=\"white\">- A cada ação, o mundo ao redor é <color=\"yellow\"> alterado.\r\n\r\n<color=\"white\">- Quanto mais próximo de <color=\"yellow\">objetos, <color=\"white\">mais nítida é sua aparência. ";
        tutorialText[3] = "<color=\"white\">- Mude o campo de visão com a <color=\"red\">ROLETA.\r\n\r\n<color=\"white\">- Confirme em <color=\"red\">SEND →.";
        tutorialText[4] = "<color=\"white\">O campo de visão não limita-se à movimentação.\r\n\r\n<color=\"white\">Não esqueça de checar a <color=\"yellow\">retaguarda <color=\"white\">de vez em quando.";
        tutorialText[5] = "- <color=\"yellow\">Obstáculos <color=\"white\">sempre permanecem <color=\"yellow\">imóveis.\r\n\r\n<color=\"white\">- Use-os para <color=\"yellow\">guiar-se pelo ambiente.";
        tutorialText[6] = "<color=\"white\">- Obstáculos de <color=\"yellow\">1 quadrado <color=\"white\">são pedras ou detritos.\r\n\r\n<color=\"white\">- Obstáculos de <color=\"yellow\">2 quadrados em diagonal <color=\"white\">são parte da vegetação.";
        tutorialText[7] = "<color=\"white\">- Para coletar um item, configure o <color=\"red\">1º SWITCH <color=\"white\">para <color=\"red\">CURSOR.\r\n\r\n<color=\"white\">- Depois, veja se o <color=\"red\">2º SWITCH <color=\"white\">está em <color=\"red\">USE.\r\n\r\n<color=\"white\">- Mire com as <color=\"red\">SETAS DE MOVIMENTAÇÃO.\r\n<color=\"white\">- Acione o <color=\"red\">BOTÃO VERMELHO <color=\"white\">para confirmar.\r\n";
        tutorialText[8] = "<color=\"white\">- Áreas mais escuras são <color=\"yellow\">corpos de água <color=\"white\"> inacessíveis no ambiente.";
        tutorialText[9] = "<color=\"white\">- O <color=\"red\">CONTADOR DE MUNIÇÃO <color=\"white\">indica projéteis do mecha.\r\n\r\n<color=\"white\">- Você pode coletar munições de <color=\"yellow\">mechas destruídos.\r\n\r\n<color=\"red\">1º SWITCH <color=\"white\">em <color=\"red\">CURSOR.\r\n\r\n<color=\"red\">2º SWITCH <color=\"white\">em <color=\"red\">USE.";
        tutorialText[10] = "<color=\"yellow\">- Ameaças <color=\"white\">tendem a se movimentar.\r\n\r\n<color=\"white\">- Quando próximas, a <color=\"red\">LUZ DE AVISO <color=\"white\">ficará amarela e emitirá um som.";
        tutorialText[11] = "<color=\"white\">- Para atirar, configure o <color=\"red\">1º SWITCH <color=\"white\">para <color=\"red\">CURSOR.\r\n\r\n<color=\"white\">- Depois, configure o <color=\"red\">2º SWITCH <color=\"white\">para <color=\"red\">GUN.\r\n\r\n<color=\"white\">- Mire com as <color=\"red\">SETAS DE MOVIMENTAÇÃO.\r\n\r\n<color=\"white\">- Acione o <color=\"red\">BOTÃO VERMELHO <color=\"white\">para confirmar.";
        tutorialText[12] = "<color=\"white\">- Treinamento concluído, piloto, avance para o <color=\"yellow\">ponto de extração <color=\"white\">para finalizar.";
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
