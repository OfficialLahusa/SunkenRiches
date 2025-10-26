using Unity.VisualScripting;
using UnityEngine;

public class ScoreTracker
{
    private static ScoreTracker instance = null;

    public static ScoreTracker Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ScoreTracker();
            }
            return instance;
        }
    }

    private ScoreTracker()
    {

    }

    public int trashCollected = 0;
    public int commonCollected = 0;
    public int rareCollected = 0;
}
