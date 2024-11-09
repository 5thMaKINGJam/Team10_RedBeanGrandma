using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PeerManager : MonoBehaviour
{
    [SerializeField] RectTransform peerTable;
    [SerializeField] GameObject peerObj;
    [SerializeField] PeerSO peerSO;
    
    Transform child;

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
            Destroy(child.gameObject);
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
                face = (int)peer + (int)(peerSO.GetPeerIdx()/ 2);
                Debug.Log($"face : {face}");
                peerEmotion.sprite = GetImg(face);
            }
        }
        peerEmotion.SetNativeSize();
    }

    private IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    public void MakePeerObj(Define.Peer peer)
    {
        GameObject clonedObj = Instantiate(peerObj);
        clonedObj.name=peer.ToString();
        clonedObj.transform.SetParent(peerTable, false);

        Sprite peerImg = GetImg((int)peer);
        Image imageComponent = clonedObj.GetComponentInChildren<Image>();
        imageComponent.sprite = peerImg;
        imageComponent.SetNativeSize();
    }

    private Sprite GetImg(int ingredIdx)
    {
        return peerSO.GetPeerImg(ingredIdx);
    }
}
