using UnityEngine;

public class NodeCheckVars : MonoBehaviour
{
    private int ID = -1;
    private int sortingOrderVar = 1000;
    public int getID() { ID++; return ID; }
    public int getSO() { sortingOrderVar--; return sortingOrderVar; }
}