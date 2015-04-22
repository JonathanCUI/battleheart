using UnityEngine;
using System.Collections;

public interface IStateMachine {
	
	void SMUpdate ();
	void SetCurrentState<T>(State<T> CurrentState);
	void ChangeState<T>(State<T> pNewState);
}
