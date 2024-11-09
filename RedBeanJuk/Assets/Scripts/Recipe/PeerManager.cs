using UnityEngine;
using UnityEngine.UI;

public class PeerManager : MonoBehaviour
{
    [SerializeField] RectTransform peerTable;
    [SerializeField] GameObject peerObj;
    [SerializeField] PeerSO peerSO;
    public void DelPeerObj() //delete first element
    {
        if (peerTable != null && peerTable.childCount > 0)
        {
            Transform child = peerTable.GetChild(0);
            Destroy(child.gameObject);
        }
    }

    public void MakePeerObj(Define.Peer peer)
    {
        GameObject clonedObj = Instantiate(peerObj);
        clonedObj.transform.SetParent(peerTable, false);

        Sprite peerImg = GetImg((int)peer);
        Image imageComponent = clonedObj.GetComponentInChildren<Image>();
        imageComponent.sprite = peerImg;
    }

    private Sprite GetImg(int ingredIdx)
    {
        return peerSO.GetIngredImg(ingredIdx);
    }
}
