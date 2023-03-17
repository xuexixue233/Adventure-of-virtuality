using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class inventorySave : MonoBehaviour
{
    public static List<GameObject> GetAllPrefabByDirectory(string path)
    {
        string[] files = Directory.GetFiles(Application.dataPath + @"\Resources" + path, "*.prefab", SearchOption.AllDirectories);
        List<GameObject> _prefabList = new List<GameObject>();
        //foreach (var item in Directory.GetFiles(Application.dataPath +@"\Resources"+path))
        //{
        //    if (item.EndsWith(".meta"))
        //    {
        //        continue;
        //    }
        //    string str = item.Replace(Application.dataPath, string.Empty);
        //    str = str.Replace(@"\","/");
        //    str = str.Replace(path + "/", string.Empty);
        //    str = str.Replace(Path.GetExtension(item), string.Empty);
        //    GameObject prefab=Resources.Load<GameObject>(path + "/" +str);//º”‘ÿ‘§÷∆ÃÂ
        //    Debug.Log(prefab);
        //    _prefabList.Add(prefab);
        //}
        GameObject _prefab;
        foreach (var _path in files)
        {
            _prefab = Resources.Load(_path, typeof(GameObject)) as GameObject;
            _prefabList.Add(_prefab);
        }
        return _prefabList;
    }
    public static void saveInventory()
    {
        string[] inventoryItem = new string[GameController.canUseItems.Count];
        if (inventoryItem != null)
        {
            for (int i = 0; i < GameController.canUseItems.Count; i++)
            {
                if (GameController.canUseItems[i] != null)
                {
                    if (GameController.canUseItems[i].Name != null)
                    {
                        inventoryItem[i] = GameController.canUseItems[i].Name;
                    }

                }
            }
            PlayerPrefsX.SetStringArray("inventoryItem", inventoryItem);
            PlayerPrefsX.SetIntArray("ItemCount", HUD.itemCount);
            PlayerPrefs.Save();

        }
    }
}
