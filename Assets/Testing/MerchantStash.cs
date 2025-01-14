using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MerchantStash", menuName = "ScriptableObjects/MerchantStash", order = 2)]
public class MerchantStash : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] items;

    // Update is called once per frame
    public GameObject[] GetRandomItems(float numObjects)
    {
        GameObject[] aux = new GameObject[(int)numObjects];
        GameObject auxInstantiate;
        for (int i = 0; i < numObjects; i++)
        {
            auxInstantiate = Instantiate(items[Random.Range(0, items.Length)]);
            auxInstantiate.SetActive(false);
            aux[i] = auxInstantiate;
        }
        return aux;
    }

}
