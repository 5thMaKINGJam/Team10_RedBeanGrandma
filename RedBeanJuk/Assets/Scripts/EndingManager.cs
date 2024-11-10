using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    //전씬에 있는 GameManager.Instance 가 dontdestroyonload야. 그거 쓸 거야.
    [SerializeField] Sprite[] endings;
    [SerializeField] Image EndingImg;

    [Header("Timing Settings")]
    [SerializeField] private float initialDisplayTime = 2f; // 초기 엔딩 이미지를 표시할 시간 (초)
    [SerializeField] private float fadeDuration = 1f; // 페이드 아웃/인 효과의 지속 시간 (초)
    [SerializeField] private float postFadeWaitTime = 1f; // 페이드 아웃 후 대기 시간 (초)
    [SerializeField] private float finalDisplayTime = 2f; // 성공/실패 엔딩 이미지를 표시할 시간 (초)

    [Header("Scene Settings")]
    [SerializeField] private string startSceneName = "StartScene"; // 게임 시작 씬의 이름

    void Start()
    {
        EndingImg.sprite = endings[0];
        EndingImg.color = new Color(EndingImg.color.r, EndingImg.color.g, EndingImg.color.b, 1f); // 알파값 1로 설정

        StartCoroutine(EndingSequence());
    }

    private IEnumerator EndingSequence()
    {
        // 1. 초기 엔딩 이미지 표시 시간만큼 대기
        yield return new WaitForSeconds(initialDisplayTime);

        // 2. 페이드 아웃 효과 적용
        yield return StartCoroutine(FadeImage(EndingImg, 1f, 0f, fadeDuration));

        // 3. 페이드 아웃 후 대기 시간만큼 대기
        yield return new WaitForSeconds(postFadeWaitTime);

        // 4. 성공 여부 확인
        bool isSuccess = false;
        if (GameManager.Instance != null)
        {
            isSuccess = GameManager.Instance.GetSuccessOrNot();
        }
        else
        {
            isSuccess = false;
        }

        // 5. 성공 여부에 따라 엔딩 이미지 변경
        if (isSuccess)
        {
            EndingImg.sprite = endings[1];
        }
        else
        {
            EndingImg.sprite = endings[2];
        }

        // 6. 페이드 인 효과 적용 (선택 사항)
        yield return StartCoroutine(FadeImage(EndingImg, 0f, 1f, fadeDuration));

        // 7. 최종 엔딩 이미지 표시 시간만큼 대기
        yield return new WaitForSeconds(finalDisplayTime);

        // 8. 게임 시작 씬으로 전환
        SceneManager.LoadScene(startSceneName);
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

        // 페이드 완료 후 정확한 알파값 설정
        img.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
