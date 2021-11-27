/*
· You need a "SaveSystem" gameObject with the "SaveSystem.cs" on it
· The "SaveSystem" gameObject needs a reference to your objectPrefab
· Your objects script needs an OnDestroy() callback to remove itself from the saves list (optional)
· Your objects script needs an Awake() callback to add itself to the saves list
· If your saving with android then Save with "OnApplicationPause()"
*/

using UnityEngine;
using UnityEngine.UI;
public class FishData //建構式
{
  public Fish fish; 
  public int value;
  public Text FishName;
  public FishData(Fish fish){   
      // value = fish.value;
      // FishName=fish.FishName;
  }
}
