using UnityEngine;

public class FishData : MonoBehaviour
{
    // Fish Data fields
    [SerializeField] private string _species;
    public string Species => _species;

    [SerializeField] private string _rarity;
    public string Rarity => _rarity;

    [SerializeField] private int _points;
    public int Points => _points;
}
