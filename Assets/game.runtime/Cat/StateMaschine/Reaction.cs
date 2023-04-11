using Game.Configurations;
using UnityEngine;

[System.Serializable]
public class Reaction
{
    [SerializeField] private string m_caption;
    [SerializeField] private CatMoodConfig m_newMood;

    public string Caption => m_caption;
    public CatMoodConfig Mood => m_newMood;
}
