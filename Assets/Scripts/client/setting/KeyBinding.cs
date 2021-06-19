using UnityEngine;

[CreateAssetMenu(fileName = "new json.json", menuName = "Json")]     // create asst menu "Json"
public class KeyBinding : ScriptableObject
{
    ReadDataFromJson jsonData = CreateInstance<ReadDataFromJson>();

    public string KeyBindings(string name)
    {
        string key = "";
        foreach (var item in JsonUtility.FromJson<JsonData>(jsonData.ReadFromJson("KeyBindingList.json")).KeyBindings)
        {
            if (name == item.name)
            {
                key = item.key;
            }
        }
        return key;
    }
}
