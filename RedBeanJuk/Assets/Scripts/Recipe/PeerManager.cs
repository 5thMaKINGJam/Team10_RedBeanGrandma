using System;
using UnityEngine;
using UnityEngine.UI;

public class PeerManager : MonoBehaviour
{
    [SerializeField] RectTransform peerTable;
    [SerializeField] PeerSO peerSO;
    
    Transform child;
    private void Awake()
    {
        child = peerTable.GetChild(0);
        child.gameObject.SetActive(false);
    }

    public void EvalPeerObj(bool isSuccess)
    {
        if (peerTable != null && peerTable.childCount > 0)
        {
            child = peerTable.GetChild(0);
            ChangePeerImg(child, isSuccess);
        }
    }
    public void DelPeerObj() //delete first element
    {
        if (peerTable != null && peerTable.childCount > 0)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void ChangePeerImg(Transform child, bool isSuccess)
    { 
        Image peerEmotion = child.GetChild(0).GetComponent<Image>();
        int face = 0;
        if (Enum.TryParse(child.name, true, out Define.Peer peer))
        {
            if (!isSuccess)
            {
                face = (int)peer + (int)(peerSO.GetPeerIdx()/ 3);
                Debug.Log($"face : {face}");
                peerEmotion.sprite = GetImg(face);
            }
        }
        peerEmotion.SetNativeSize();
    }

    public void MakePeerObj(Define.Peer peer)
    {
        child.gameObject.SetActive(true);
        child.name=peer.ToString();

        Sprite peerImg = GetImg((int)peer);
        Image imageComponent = child.GetComponentInChildren<Image>();
        imageComponent.sprite = peerImg;
        imageComponent.SetNativeSize();
    }

    private Sprite GetImg(int ingredIdx)
    {
        return peerSO.GetPeerImg(ingredIdx);
    }
}