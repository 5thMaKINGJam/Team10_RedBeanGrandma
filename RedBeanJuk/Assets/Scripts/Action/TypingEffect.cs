using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text uiText;
    string fullText = "아주 먼 옛날 깊은 산 속에\n팥죽을 아주 잘 끓이는 할머니가 살고 있었습니다.\n\n어느 봄날 호랑이가 내려와\n할머니를 잡아먹으려고 하였습니다.\n\n할머니는 동짓날 맛있는 팥죽을 끓여줄테니\n기다려달라고 호랑이를 구슬렸습니다.\n\n호랑이는 동짓날 다시 오겠다고 하고\n훌쩍 산속으로 돌아갔습니다.\n\n동짓날 아침이 되자 할머니는 호랑이가\n잡아 먹으러 온다는 생각에 울고 있었습니다.\n\n그 모습을 보고 알밤, 거북이, 진흙, 송곳, 절구가 찾아왔고\n맛있는 팥죽을 주면 할머니를 도와주겠다고 합니다.\n\n그럼 팥죽을 끓이러 가볼까요?  ";
    public float typingSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        uiText.text = "";
        for (int i = 0; i < fullText.Length; i++)
        {
            uiText.text += fullText[i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
