using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    public string Name;
    public GameObject BoxPrefab;
    public int Value;
    public string[] StorageTags; //empty normal, else it needs to be stored in a funky way
    public int SpoilTimer; //if >0 and no special tag then count down, if -1 can not spoil
}
