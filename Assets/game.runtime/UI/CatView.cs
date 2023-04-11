using Game.Configurations;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatView : MonoBehaviour
{
    [SerializeField] private ActionButton m_ActionButtonPref;
    [SerializeField] private Transform m_ButtonContainer;

    [SerializeField] private TMP_Text m_TextMood;
    [SerializeField] private TMP_Text m_TextReaction;

    private List<ActionButton> m_actionButtons = new List<ActionButton>();
    private List<string> actionNames = new List<string>();

    public void UpdateMood(CatMoodConfig mood) => m_TextMood.text = mood.Caption;
    public void UpdateReaction(Reaction reaction) => m_TextReaction.text = reaction.Caption;

    private void Start()
    {
        m_TextReaction.text = string.Empty;
    }

    // Пулл вроде как не требуется, сделал обычным Instantiate. 
    public void AddActionButton(string caption, Action onClick)
    {
        if (actionNames.Contains(caption)) return;
        actionNames.Add(caption);

        var button = Instantiate<ActionButton>(m_ActionButtonPref, m_ButtonContainer);
        button.Construct(caption, onClick);
        m_actionButtons.Add(button);
    }

    private void OnDestroy()
    {
        m_actionButtons.ForEach(btn => Destroy(btn.gameObject));
        actionNames = null;
    }

}
