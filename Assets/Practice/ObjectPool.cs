using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> _poolObjList;
    private GameObject _poolObj;
    public void CreatePool(GameObject obj,int countMax)
    {
        _poolObj = obj;
        _poolObjList = new List<GameObject>();

        for (int i = 0; i < countMax; i++)
        {
            var newObj = CreateNewObject();
            newObj.SetActive(false);
            _poolObjList.Add(newObj);
        }
    }
    
    
    public GameObject GetObject(){
        foreach (var obj in _poolObjList) {
            if (obj.activeSelf == false) {
                obj.SetActive(true);
                return obj;
            }
        }

        var newObj = CreateNewObject();
        newObj.SetActive(true);
        _poolObjList.Add(newObj);

        return newObj;
    }

    private GameObject CreateNewObject(){
        var newObj = Instantiate(_poolObj);
        newObj.name = _poolObj.name + (_poolObjList.Count + 1);

        return newObj;
    }

}
