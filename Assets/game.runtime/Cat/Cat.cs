using Game.Configurations;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] private CatMoodConfig startMoodState;
    [SerializeField] private CatView catViewPref;   //Префаб своего интерфейса
    [SerializeField] StateMaschine stateMaschine;

    private CatMoodConfig _currentMood;
    private CatView _view;

    void Start()
    {
        _currentMood = startMoodState;

        CreateView();
        _view.UpdateMood(startMoodState);

        foreach (var state in stateMaschine.States)
        {
            var catAction = state.CatAction;
            var reaction = state.CatReaction;
            _view.AddActionButton(catAction.Caption, ()=>OnReactionApply(catAction));
        }
    }


    private void CreateView()
    {
        _view = Instantiate<CatView>(catViewPref);

    }

    private void OnReactionApply(CatActionConfig action)
    {
        //var newMood = reaction.Mood;
        var reaction = stateMaschine.SwichState(action, _currentMood);
        if (reaction == null) return;
        if (reaction.Mood == null) return;

        _currentMood = reaction.Mood;

        _view.UpdateMood(_currentMood);
        _view.UpdateReaction(reaction);
    }

    
}
