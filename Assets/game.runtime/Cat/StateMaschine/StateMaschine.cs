using Game.Configurations;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMaschine
{
    [SerializeField] private List<State> states = new List<State>();

    public List<State> States => states;

    private CatActionConfig m_currentActionConfig;
    private CatMoodConfig m_currentMoodConfig;

    public Reaction SwichState(CatActionConfig catAction, CatMoodConfig catMood)
    {
        foreach (var state in states) {
            
            if (state == null) continue;
            
            if (state.CatAction == catAction && state.CatMood == catMood)
            {
                return ApplyState(state);
            }
        }

        Debug.Log("Реакция на состояние не существует. Состояние не изменилось.");
        return null;
    }

    private Reaction ApplyState(State state)
    {
        if (m_currentActionConfig == state.CatAction && m_currentMoodConfig == state.CatMood)
        {
            Debug.Log("Реакция не изменилась.");
        }
        else
        {
            Debug.Log($"Новая реакция: {state.CatReaction.Caption}");
            m_currentActionConfig = state.CatAction;
            m_currentMoodConfig = state.CatMood;
        }
        return state.CatReaction;
    }
}