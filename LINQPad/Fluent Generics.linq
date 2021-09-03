<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

async void Main()
{
	var cancelation = new CancellationTokenSource();
	cancelation.Cancel();
	
	var test = new SignInEndpoint();
	
	var darren = await test.ExecuteAsync(new SignInRequest { Username = "darren" });
	var notDarren = await test.ExecuteAsync(new SignInRequest { Username = "notDarren" });
	var darrenCanceled = await test.ExecuteAsync(new SignInRequest { Username = "darren" }, cancelation.Token);
	
	Console.WriteLine(darren);
	Console.WriteLine(notDarren);
	Console.WriteLine(darrenCanceled);
	
	var simple = new SimpleEndpoint();
	await simple.ExecuteAsync();
	await simple.ExecuteAsync(cancelation.Token);
}



// You can define other methods, fields, classes and namespaces here
public static class Endpoint
{
	public static class WithRequest<TReq>
	{
		public abstract class WithResponse<TRes>
		{
			public abstract Task<TRes> ExecuteAsync(
				TReq request,
				CancellationToken cancellationToken = default
			);
		}

		public abstract class WithoutResponse
		{
			public abstract Task ExecuteAsync(
				TReq request,
				CancellationToken cancellationToken = default
			);
		}
	}

	public static class WithoutRequest
	{
		public abstract class WithResponse<TRes>
		{
			public abstract Task<TRes> ExecuteAsync(
				CancellationToken cancellationToken = default
			);
		}

		public abstract class WithoutResponse
		{
			public abstract Task ExecuteAsync(
				CancellationToken cancellationToken = default
			);
		}
	}
}

public class SignInRequest
{
	public string Username { get; set; }
	public string Password { get; set; }
}

public class SignInResponse
{
	public string Token { get; set; }
}

public class SignInEndpoint : Endpoint.WithRequest<SignInRequest>.WithResponse<SignInResponse>
{
	public async override Task<SignInResponse> ExecuteAsync(SignInRequest request, CancellationToken cancellationToken = default)
	{
		if(cancellationToken.IsCancellationRequested) return null;

		if (request.Username.Equals("darren")) return await Task.FromResult(new SignInResponse { Token = "The Dude"});
		
		return await Task.FromResult(new SignInResponse { Token = "Failure"});
	}
}

public class SimpleEndpoint : Endpoint.WithoutRequest.WithoutResponse
{
	public async override Task ExecuteAsync(CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();
		await Task.Delay(100);
		return;
	}
}