using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private AnimationClip _animationClip;
    public GameObject HoverButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Animation hoverAnimaton = HoverButton.GetComponent<Animation>();
        if (hoverAnimaton != null)
        {
            //hoverAnimaton.isHover = true;
        }
        //trigger ¸ØÃã? ´Þ´Þ ¶°´Â °Å? hoverAnim7aton.Play(_animationClip.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Animation hoverAnimation = HoverButton.GetComponent<Animation>();
        hoverAnimation.Stop(_animationClip.name);
    }

}
