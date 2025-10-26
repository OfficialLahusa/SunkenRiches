using TMPro;
using UnityEngine;

public class CollectibleDisplay : MonoBehaviour
{
    public TMP_Text trashText;
    public TMP_Text commonText;
    public TMP_Text rareText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trashText.SetText(ScoreTracker.Instance.trashCollected.ToString());
        commonText.SetText(ScoreTracker.Instance.commonCollected.ToString());
        rareText.SetText(ScoreTracker.Instance.rareCollected.ToString());
    }
}
