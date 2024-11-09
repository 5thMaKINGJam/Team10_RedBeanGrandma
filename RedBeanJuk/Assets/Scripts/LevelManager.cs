using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stageText;

    [SerializeField] ShuffleButton shuffleButton;
    [SerializeField] Button onSubmitButton;

    [SerializeField] GameObject keyboard;

    int defaultMaxIngred;
    int maxIngred;
    bool isKeyboardActive = false;

    private void Awake()
    {
        if (keyboard != null)
            keyboard.SetActive(false);

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
                StartOrder();
                break;
            case 2://stage2 : 2 ~ 8
                StartOrder(defaultMaxIngred);
                break;
            case 3://stage3 : 2 ~ 8, mix random
                onSubmitButton.onClick.AddListener(ShuffleTrigger);
                StartOrder(defaultMaxIngred);
                break;
            case 4://stage 4 : 2 ~ 8, seol geo ji
                onSubmitButton.onClick.AddListener(ShuffleTrigger);
                StartOrder(defaultMaxIngred);
                Debug.Log("TODO 설거지");
                //TODO : 설거지
                break;
            case 5: //stage 5 : 2 ~ 8, ho rang ee
                onSubmitButton.onClick.AddListener(ShuffleTrigger);
                StartOrder(defaultMaxIngred);
                isKeyboardActive = true;
                break;

            default: break;
        }
    }

    private void StartOrder(int maxIngred = 3)
    {
        Debug.Log($"defaultMaxIngred : {defaultMaxIngred}, {maxIngred}");
        RecipeManager.ReciManager.SetMaxgred(maxIngred);
    }

    private void ShuffleTrigger()
    {
        shuffleButton.ShuffleIngred();
    }

    public void KeyBoard()
    {
        if (isKeyboardActive && keyboard != null)
        {
            RecipeManager.ReciManager.DeleteRecipe();
            keyboard.SetActive(true);
        }
    }
}
