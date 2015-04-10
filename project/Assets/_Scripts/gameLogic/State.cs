using UnityEngine;
using System.Collections;

/**
 * Desmond
 * 
 * base robot state
 * */
public class State<T> {

	public T Target ;
	//进入状态  
	public virtual void Enter (T entityType)
	{
		
	}
	
	//状态正常执行
	public virtual void Execute (T entityType)
	{
		
	}
	
	//退出状态
	public virtual void Exit (T entityType)
	{
		
	}
}
