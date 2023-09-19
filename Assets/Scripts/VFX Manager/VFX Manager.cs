using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SamEbac.Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        Jump,
        PlayerDust,
        Coin,
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayerVFXByType(VFXType vfxType, Vector3 position)
    {
        

        foreach (var i in vfxSetup)
        {
            if(i.vFXType == vfxType)
            {
                var item = Instantiate(i.prefabs);
                item.transform.position = position;
                Destroy(gameObject, 5f);
                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vFXType;
    public GameObject prefabs;
}