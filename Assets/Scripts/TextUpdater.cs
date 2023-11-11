using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] TMP_Text screenText;
    [SerializeField] Animator animText;
    [SerializeField] string[] tutorialTextPTBR = new string[13];
    [SerializeField] string[] tutorialTextENG = new string[13];
    public bool isEnglish = false;
    // Start is called before the first frame update
    void Start()
    {
        screenText = GetComponent<TMP_Text>();
        animText = GetComponent<Animator>();
        #region PTBR text
        tutorialTextPTBR[1] = "<color=\"white\">-  Para movimentar-se, veja se o <color=\"red\">1º SWITCH<color=\"white\"> está em <color=\"red\">MOVE.\r\n\r\n<color=\"white\">- Depois, use as <color=\"red\">SETAS DE MOVIMENTAÇÃO.";
        tutorialTextPTBR[2] = "<color=\"white\">- A cada ação, o mundo ao redor é <color=\"yellow\"> alterado.\r\n\r\n<color=\"white\">- Quanto mais próximo de <color=\"yellow\">objetos, <color=\"white\">mais nítida é sua aparência. ";
        tutorialTextPTBR[3] = "<color=\"white\">- Mude o campo de visão com a <color=\"red\">ROLETA.\r\n\r\n<color=\"white\">- Confirme em <color=\"red\">SEND →.";
        tutorialTextPTBR[4] = "<color=\"white\">- Você sempre pode mudar seu campo de visão.\r\n\r\n<color=\"white\">- Por isso, cheque a <color=\"yellow\">retaguarda <color=\"white\">de vez em quando.";
        tutorialTextPTBR[5] = "- <color=\"yellow\">Obstáculos <color=\"white\">sempre permanecem <color=\"yellow\">imóveis.\r\n\r\n<color=\"white\">- Use-os para <color=\"yellow\">guiar-se pelo ambiente.";
        tutorialTextPTBR[6] = "<color=\"white\">- Obstáculos de <color=\"yellow\">1 quadrado <color=\"white\">são pedras ou detritos.\r\n\r\n<color=\"white\">- Obstáculos de <color=\"yellow\">2 quadrados em diagonal <color=\"white\">são parte da vegetação.";
        tutorialTextPTBR[7] = "<color=\"white\">- Para coletar um item, configure o <color=\"red\">1º SWITCH <color=\"white\">para <color=\"red\">CURSOR.\r\n\r\n<color=\"white\">- Depois, veja se o <color=\"red\">2º SWITCH <color=\"white\">está em <color=\"red\">USE.\r\n\r\n<color=\"white\">- Mire com as <color=\"red\">SETAS DE MOVIMENTAÇÃO.\r\n<color=\"white\">- Acione o <color=\"red\">BOTÃO VERMELHO <color=\"white\">para confirmar.\r\n";
        tutorialTextPTBR[8] = "<color=\"white\">- Áreas mais escuras são <color=\"yellow\">corpos de água <color=\"white\"> inacessíveis no ambiente.";
        tutorialTextPTBR[9] = "<color=\"white\">- O <color=\"red\">CONTADOR DE MUNIÇÃO <color=\"white\">indica projéteis do mecha.\r\n\r\n<color=\"white\">- Você pode coletar munições de <color=\"yellow\">mechas destruídos.\r\n\r\n<color=\"red\">1º SWITCH <color=\"white\">em <color=\"red\">CURSOR.\r\n\r\n<color=\"red\">2º SWITCH <color=\"white\">em <color=\"red\">USE.";
        tutorialTextPTBR[10] = "<color=\"yellow\">- Ameaças <color=\"white\">tendem a se movimentar.\r\n\r\n<color=\"white\">- Quando próximas, a <color=\"red\">LUZ DE AVISO <color=\"white\">ficará amarela e emitirá um som.";
        tutorialTextPTBR[11] = "<color=\"white\">- Para atirar, configure o <color=\"red\">1º SWITCH <color=\"white\">para <color=\"red\">CURSOR.\r\n\r\n<color=\"white\">- Depois, configure o <color=\"red\">2º SWITCH <color=\"white\">para <color=\"red\">GUN.\r\n\r\n<color=\"white\">- Mire com as <color=\"red\">SETAS DE MOVIMENTAÇÃO.\r\n\r\n<color=\"white\">- Acione o <color=\"red\">BOTÃO VERMELHO <color=\"white\">para confirmar.";
        tutorialTextPTBR[12] = "<color=\"white\">- Treinamento concluído! Colete o <color=\"yellow\">item <color=\"white\">e vá ao <color=\"yellow\">ponto de extração <color=\"white\">para finalizar.";
        #endregion
        #region ENG text
        tutorialTextENG[1] = "<color=\"white\">- To move your mech, see if the <color=\"red\">1st SWITCH<color=\"white\"> is on <color=\"red\">MOVE.\r\n\r\n<color=\"white\">- Then, use the <color=\"red\">ARROW KEYS.";
        tutorialTextENG[2] = "<color=\"white\">- The world around <color=\"yellow\">reacts <color=\"white\">with each action.\r\n\r\n<color=\"white\">- If you are close to objects, <color=\"yellow\">they will be easier to see.";
        tutorialTextENG[3] = "<color=\"white\">- Change your field of view with the <color=\"red\">DIAL.\r\n\r\n<color=\"white\">- Confirm the action with <color=\"red\">SEND →.";
        tutorialTextENG[4] = "<color=\"white\">You can always change your field of view.\r\n\r\n<color=\"white\">So, check your <color=\"yellow\">surroundings <color=\"white\">regularly. ";
        tutorialTextENG[5] = "- <color=\"yellow\">Obstacles <color=\"white\">are always <color=\"yellow\">motionless.\r\n\r\n<color=\"white\">- Use them to <color=\"yellow\">guide yourself <color=\"white\">through the world.";
        tutorialTextENG[6] = "<color=\"yellow\">1 Square Obstacles <color=\"white\">are usually rocks and debris.\r\n\r\n<color=\"yellow\">2 Diagonal Squares Obstacles <color=\"white\">are the vegetation, like trees.";
        tutorialTextENG[7] = "<color=\"white\">- To collect an item, change the <color=\"red\">1st SWITCH<color=\"white\"> to <color=\"red\">CURSOR.\r\n\r\n<color=\"white\">- Then, see if the <color=\"red\">2nd SWITCH <color=\"white\">is on <color=\"red\">USE.\r\n\r\n<color=\"white\">- Aim with the <color=\"red\">ARROW KEYS.\r\n\r\n<color=\"white\">- Use the <color=\"red\">RED BUTTON <color=\"white\">to confirm.";
        tutorialTextENG[8] = "<color=\"white\">- Darker areas are <color=\"yellow\">inaccessible <color=\"white\">and represent a <color=\"yellow\">river <color=\"white\">or a <color=\"yellow\">waterfall.";
        tutorialTextENG[9] = "<color=\"white\">- The <color=\"red\">AMMO COUNTER <color=\"white\">shows your current bullets.";
        tutorialTextENG[10] = "<color=\"yellow\">- Threats <color=\"white\">can usually make a move.\r\n\r\n<color=\"white\">- When nearby, the <color=\"red\">WARNING LIGHT <color=\"white\">will trigger and <color=\"yellow\">flash in yellow.";
        tutorialTextENG[11] = "<color=\"white\">- To shoot, see if the <color=\"red\">1st SWITCH<color=\"white\"> is on<color=\"red\">CURSOR.\r\n\r\n<color=\"white\">- Then, change the <color=\"red\">2nd SWITCH <color=\"white\">to <color=\"red\">GUN.\r\n\r\n<color=\"white\">- Aim with the <color=\"red\">ARROW KEYS.\r\n\r\n<color=\"white\">- Use the <color=\"red\">RED BUTTON <color=\"white\">to confirm.";
        tutorialTextENG[12] = "<color=\"white\">- Training Complete! Collect the <color=\"yellow\">item <color=\"white\">and go to the <color=\"yellow\">Extraction Point <color=\"white\">to progress.";
        #endregion
        screenText.text = "Welcome Aboard Pilot!";
    }
    public void SetTutorialText(int stage)
    {
        if (!isEnglish)
        {
            screenText.text = tutorialTextPTBR[stage];
        }
        else
        {
            screenText.text = tutorialTextENG[stage];
        }
        animText.Play("TextFlash");
    }
    public void SendTextMessage(string msg)
    {
        screenText.text = msg;
        animText.Play("TextFlash");
    }
}
