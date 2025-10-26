using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();

        int totalScore = 30 * ScoreTracker.Instance.trashCollected + 100 * ScoreTracker.Instance.commonCollected + 250 * ScoreTracker.Instance.rareCollected;

        text.SetText($"Trash collected: {ScoreTracker.Instance.trashCollected}\n"
            + $"Common collected: {ScoreTracker.Instance.commonCollected}\n"
            + $"Rare collected: {ScoreTracker.Instance.rareCollected}\n\n"
            + $"Total score: {totalScore}");
    }
}
