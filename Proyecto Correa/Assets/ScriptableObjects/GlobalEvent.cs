using UnityEngine;

public abstract class GlobalEvent : ScriptableObject
{
    public abstract void Raise(); // Método que los eventos implementarán
}
