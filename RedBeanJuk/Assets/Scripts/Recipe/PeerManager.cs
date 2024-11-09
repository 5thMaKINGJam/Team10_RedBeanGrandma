using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PeerManager : MonoBehaviour
{
    [SerializeField] RectTransform peerTable;
    [SerializeField] GameObject peerObj;
    [SerializeField] PeerSO peerSO;
    int delaySeconds = 2;
    public void DelPeerObj(bool isSuccess) //delete first element
    {
        if (peerTable != null && peerTable.childCount > 0)
        {
            Transform child = peerTable.GetChild(0);
            ChangePeerImg(child, isSuccess);
            StartCoroutine(DestroyAfterDelay(child.gameObject, delaySeconds));
        }
    }

    private void ChangePeerImg(Transform child, bool isSuccess)
    { 
        Image peerEmotion = child.GetComponent<Image>();
        int face = 0;
        if (Enum.TryParse(child.name, true, out Define.Peer peer))
        {
            if (!isSuccess)
            {
                face = (int)peer + (peerSO.GetIngredIdx()/ 2);
                peerEmotion.sprite = GetImg(face);
            }
        }
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
    }

    private Sprite GetImg(int ingredIdx)
    {
        return peerSO.GetIngredImg(ingredIdx);
    }
}
