using Unity.VisualScripting;
using UnityEngine;

public class CollectibleTracker
{
    private static CollectibleTracker instance = null;

    public static CollectibleTracker Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CollectibleTracker();
            }
            return instance;
        }
    }

    private CollectibleTracker()
    {

    }

    public int trashCollected = 0;
    public int commonCollected = 0;
    public int rareCollected = 0;
}
