<Query Kind="Program" />

void Main()
{
	var pipe = new PipeBuilder(First)
				.AddPipe(typeof(Try))
				.AddPipe(typeof(Wrap))
				.Build();
			
	pipe("Hello");
}


public void First(string msg)
{
	$"\texecuting {msg}".Dump("first function");
}

public void Second(string msg)
{
	$"\texecuting {msg}".Dump("second function");
}


public abstract class Pipe
{
	protected Action<string> _action;
	
	public Pipe(Action<string> action)
	{
		_action = action;
	}
	
	public abstract void Handle(string msg);
}

public class PipeBuilder
{
	Action<string> _mainAction;
	
	List<Type> _pipeTypes = new List<Type>();
	
	public PipeBuilder(Action<string> mainAction)
	{
		_mainAction = mainAction;
	}
	
	public PipeBuilder AddPipe(Type pipeType)
	{
		_pipeTypes.Add(pipeType);
		return this;
	}
	
	
	private Action<string> CreatePipe(int index)
	{
		if(index < _pipeTypes.Count - 1)
		{
			var childPipeHandle = CreatePipe(index + 1);
			var pipe = (Pipe) Activator.CreateInstance(_pipeTypes[index], childPipeHandle);
			return pipe.Handle;
		}
		else
		{
			var finalPipe = (Pipe) Activator.CreateInstance(_pipeTypes[index], _mainAction);
			return finalPipe.Handle;
		}
	}
	
	public Action<string> Build()
	{
		var pipe = CreatePipe(0);
		
		return pipe;
	}
}

public class Wrap : Pipe
{
	public Wrap(Action<string> action) : base(action){}
	
	public override void Handle(string msg)
	{
		msg.Dump("\tstarting");
		_action(msg);
		"\tends".Dump();

	}
}

public class Try : Pipe
{
	public Try(Action<string> action) : base(action) { }

	public override void Handle(string msg)
	{
		try
		{	        
			"trying....".Dump();
			_action(msg);
		}
		catch (Exception ex)
		{
			"failed!".Dump();
			ex.Dump();
		}
		finally
		{
			"... done trying.".Dump();
		}
	}
}