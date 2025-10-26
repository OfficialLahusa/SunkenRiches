using TMPro;
using UnityEngine;

public class CollectibleDisplay : MonoBehaviour
{
    public CollectiblePicker picker;
    TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText($"Trash: {CollectibleTracker.Instance.trashCollected}\nCommon: {CollectibleTracker.Instance.commonCollected}\nRare: {CollectibleTracker.Instance.rareCollected}");
    }
}
