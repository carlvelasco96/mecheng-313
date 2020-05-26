class FiniteStateTable
{
	int[,] FST = new int[3,2]; //3 rows 2 cols
	
	struct cell_FST //groups variables of a cell (indexOfNextState and action)
	{
		public int indexOfNextState;
		public string action;
	}

	//set indexOfNextState of cell
	public void SetNextState(int stateIndex, int newIndexOfNextState)
	{
		FST(state, 2).indexOfNextState = newIndexOfNextState;
	}
	
	//set action of cell
	public void SetActions(int stateIndex, string newAction) 
	{
		FST(state, 2).action = newAction;
	}
	
	//return indexOfNextState of cell
	public string GetNextState(int stateIndex) 
	{
		return FST(state, 2).indexOfNextState;
	}
	
	//return action of cell
	public string GetActions(int stateIndex) 
	{
		return FST(state, 1).action;
	}
	
	
	static void Main()
	{
		
		
		
		
	}
}