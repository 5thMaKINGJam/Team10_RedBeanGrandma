using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stageText;

    [SerializeField] ShuffleButton shuffleButton;
    [SerializeField] Button onSubmitButton;

    int defaultMaxIngred;
    int maxIngred;
    bool isKeyboardActive = false;
    bool isDishWashActive = false;

    private void Awake()
    {
        defaultMaxIngred = (int)Ingredient.MaxCount - 2;

        isKeyboardActive = false;
    }
    public void StartStage(int currentStage)
    {
        stageText.text = currentStage.ToString();
        onSubmitButton.onClick.RemoveAllListeners();

        switch (currentStage)
        {
            case 1://stage1 : 2 ~ 5
                StartOrder(3);
                break;
            case 2://stage2 : 2 ~ 8
                StartOrder(4);
                break;
            case 3://stage3 : 2 ~ 8, mix random
                onSubmitButton.onClick.AddListener(ShuffleTrigger);
                StartOrder(5);
                break;
            case 4://stage 4 : 2 ~ 8, seol geo ji
                onSubmitButton.onClick.AddListener(ShuffleTrigger);
                StartOrder(6);
                isDishWashActive = true;
                break;
            case 5: //stage 5 : 2 ~ 8, ho rang ee
                onSubmitButton.onClick.AddListener(ShuffleTrigger);
                StartOrder(6);
                isKeyboardActive = true;
                break;

            default: break;
        }
    }

    private void StartOrder(int maxIngred = 3)
    {
        RecipeManager.ReciManager.SetMaxgred(maxIngred);
    }

    private void ShuffleTrigger()
    {
        shuffleButton.ShuffleChildren();
    }
}
