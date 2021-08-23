using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveSymbolsList: MonoBehaviour
{
    private List<Symbol> symbolsList;

    public List<Symbol> GetSymbolsList()
    {
        return symbolsList;
    }

    public void SetSymbolsList(List<Symbol> sl)
    {
        symbolsList = sl;
    }
}
