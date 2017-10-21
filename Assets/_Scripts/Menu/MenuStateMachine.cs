using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuStateMachine : MonoBehaviour {

    public List<MenuState> m_MenuStates = new List<MenuState>();

    Stack<MenuState> m_StateStack = new Stack<MenuState>();

    public void PushState<T>() where T : MenuState {
        MenuState state = m_MenuStates.FirstOrDefault(s => s is T);
        state = Instantiate(state, transform, false);

        m_StateStack.Push(state);
    }

    public void PopState() {
        MenuState state = m_StateStack.Pop();
        Destroy(state.gameObject);
    }
}
