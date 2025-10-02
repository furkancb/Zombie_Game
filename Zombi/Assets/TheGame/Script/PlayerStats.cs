using UnityEngine;
using System.Collections;
public class PlayerStats : MonoBehaviour
{
    int _zombiesKilled = 0;
    public int ZombiesKilled { get { return _zombiesKilled; } set { _zombiesKilled = value; } }
}