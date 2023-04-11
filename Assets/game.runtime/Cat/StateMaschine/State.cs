using Game.Configurations;
using UnityEngine;

[System.Serializable]
public class State
{
    [SerializeField] private CatActionConfig m_action;
    [SerializeField] private CatMoodConfig m_mood;
    [SerializeField] private Reaction m_reaction;

    public CatActionConfig CatAction => m_action;
    public CatMoodConfig CatMood => m_mood;
    public Reaction CatReaction => m_reaction;

}
