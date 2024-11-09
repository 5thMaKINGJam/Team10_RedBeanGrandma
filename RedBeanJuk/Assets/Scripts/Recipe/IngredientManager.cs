using UnityEngine;
using UnityEngine.UI;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] RectTransform ingreidentTable;
    [SerializeField] GameObject ingreidentObj;
    [SerializeField] IngredSO ingredSO;

    public void DelIngreidentObj()
    {
        foreach (Transform child in ingreidentTable)
        {
            Destroy(child.gameObject);
        }
    }

    public void MakeIngreidentObj(Define.Ingredient ingredient)
    {
        GameObject clonedObj = Instantiate(ingreidentObj);
        clonedObj.transform.SetParent(ingreidentTable, false);
        IngredientImgSetter ingredientImgSetter = clonedObj.GetComponent<IngredientImgSetter>();

        if (ingredientImgSetter != null)
        {
            Sprite ingredImg = GetImg((int)ingredient);
            ingredientImgSetter.SetIngredient(ingredient, ingredImg);    
        }
    }

    private Sprite GetImg(int ingredIdx)
    {
        return ingredSO.GetIngredImg(ingredIdx);
    }

    public void MoveCheck(int ingredIdx)
    {
        Transform child = ingreidentTable.GetChild(ingredIdx);
        Transform checkChild = child.Find("Check");
        checkChild.gameObject.SetActive(true);
    }
}
