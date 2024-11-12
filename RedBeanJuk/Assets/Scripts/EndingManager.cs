using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    //������ �ִ� GameManager.Instance �� dontdestroyonload��. �װ� �� �ž�.
    [SerializeField] Sprite[] endings;
    [SerializeField] Image EndingImg;
    [SerializeField] bool isHappy;

    [Header("Timing Settings")]
    [SerializeField] private float initialDisplayTime = 2f; // �ʱ� ���� �̹����� ǥ���� �ð� (��)
    [SerializeField] private float fadeDuration = 1f; // ���̵� �ƿ�/�� ȿ���� ���� �ð� (��)
    [SerializeField] private float postFadeWaitTime = 1f; // ���̵� �ƿ� �� ��� �ð� (��)
    [SerializeField] private float finalDisplayTime = 2f; // ����/���� ���� �̹����� ǥ���� �ð� (��)

    [Header("Scene Settings")]
    [SerializeField] private string startSceneName = "StartScene"; // ���� ���� ���� �̸�

    void Start()
    {
        EndingImg.sprite = endings[0];
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Tiger);
        EndingImg.color = new Color(EndingImg.color.r, EndingImg.color.g, EndingImg.color.b, 1f); // ���İ� 1�� ����

        StartCoroutine(EndingSequence());
    }


    private IEnumerator EndingSequence()
    {
        // 1. �ʱ� ���� �̹��� ǥ�� �ð���ŭ ���
        yield return new WaitForSeconds(initialDisplayTime);
        
        // 2. ���̵� �ƿ� ȿ�� ����
        yield return StartCoroutine(FadeImage(EndingImg, 1f, 0f, fadeDuration));

        // 3. ���̵� �ƿ� �� ��� �ð���ŭ ���
        yield return new WaitForSeconds(postFadeWaitTime);

        // 5. ���� ���ο� ���� ���� �̹��� ����
        if (isHappy)
        {
            EndingImg.sprite = endings[1];
        }
        else
        {
            EndingImg.sprite = endings[2];
        }

        // 6. ���̵� �� ȿ�� ���� (���� ����)
        yield return StartCoroutine(FadeImage(EndingImg, 0f, 1f, fadeDuration));

        // 7. ���� ���� �̹��� ǥ�� �ð���ŭ ���
        yield return new WaitForSeconds(finalDisplayTime);

        // 8. ���� ���� ������ ��ȯ
        SceneManager.LoadScene("_1FirstScene");
    }

    private IEnumerator FadeImage(Image img, float startAlpha, float endAlpha, float duration)
    {
        float elapsed = 0f;
        Color color = img.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            img.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // ���̵� �Ϸ� �� ��Ȯ�� ���İ� ����
        img.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
