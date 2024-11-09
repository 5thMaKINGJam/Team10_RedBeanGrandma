using UnityEngine;
using UnityEngine.EventSystems;

public class hoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private AnimationClip _animationClip;
    public GameObject HoverButton;
    Animation hoverAnimation;
    Animator hoverAnimator;

    private void Start()
    {
        hoverAnimation = HoverButton.GetComponent<Animation>();
        hoverAnimator = HoverButton.GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverAnimation != null)
        {
            //hoverAnimator.SetBool("isHover", true);
        }

        //DOTween ½á¼­ this.scale(1.5f, 1.5f, 1.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverAnimation.Stop(_animationClip.name);
        if (hoverAnimation != null)
        {
            //hoverAnimator.SetBool("isHover", false);
        }
    }

}
