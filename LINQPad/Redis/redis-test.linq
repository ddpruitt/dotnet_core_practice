<Query Kind="Program">
  <NuGetReference>StackExchange.Redis</NuGetReference>
  <Namespace>StackExchange.Redis</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="redisAddress" value="localhost" />
          <add key="apiAddress" value="http://localhost/elcapi" />
          <add key="client_id" value="ApiTestClient" />
          <add key="client_secret" value="ljkQGFpQwHTm4GTAgjcOjWzSqf5eVLOnaUg48bxyYoQT7z2HR03tUfLuamumhKK6ghbDrz2T+ijDBTGGgRL+htByBRztM8FgltbWqZ4XKnYyBZ6r2ndWyylavnFvU28PUOchO6g466HVL4POIRphY32NeW2Lyt5iSeNmR0MNrSvCAkIJcu1gEHwa/jk64CXk0dQPYZ2cOgInd2y4fHQVd/7HvhLDFCWKBJ1qtbmRRsNasdRdNErf0TAcFsCqH79SnxNFdkLUrthpvEOIYFFVhVqDzEh1h/ANPAqw+kYboTiL6Fswh2UPtXm171Bw0WDPKIkz+oSs+XEzhy1kux1YMg==" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

async Task Main()
{
	await RedisTest();
}

private async Task RedisTest()
{
	ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

	IDatabase db = redis.GetDatabase();

	string value = "redis-is-available";
	await db.StringSetAsync("mykey", value);

	string valueGet = await db.StringGetAsync("mykey");
	Console.WriteLine(valueGet); // writes: "redis-is-available"
}

private async Task RedisTest_NoValue()
{
	ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

	IDatabase db = redis.GetDatabase();

	string value = "redis-is-available";
	await db.StringSetAsync("mykey", "");


	// HasValue is false even thoughg the key exists because the value is technically empty
	RedisValue valueGet = await db.StringGetAsync("mykey");

	valueGet.Dump();
}