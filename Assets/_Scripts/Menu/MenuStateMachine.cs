using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuStateMachine : MonoBehaviour {

    public static MenuStateMachine Instance { get; private set; }

    public List<MenuState> m_MenuStates = new List<MenuState>();

    Stack<MenuState> m_StateStack = new Stack<MenuState>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            throw new System.Exception("Second MenuStateMachhine");
        }
    }

    public void PushState<T>() where T : MenuState {
        MenuState state = m_MenuStates.FirstOrDefault(s => s is T);
        state = Instantiate(state, transform, false);

        m_StateStack.Peek().gameObject.SetActive(false);

        m_StateStack.Push(state);
    }

    public void PopState() {
        MenuState state = m_StateStack.Pop();
        Destroy(state.gameObject);

        SetStackTopActive(true);
    }

    void SetStackTopActive(bool active) {
        if(m_StateStack.Count > 0)
            m_StateStack.Peek().gameObject.SetActive(active);
    }
}
