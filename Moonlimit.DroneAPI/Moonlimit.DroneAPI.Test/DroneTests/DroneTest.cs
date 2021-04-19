using Moonlimit.DroneAPI.Entity;

namespace Moonlimit.DroneAPI.Test
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Net;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Text;
	using System.Threading.Tasks;
	using Moonlimit.DroneAPI.Api;
	using Moonlimit.DroneAPI.Domain;
	using IdentityModel.Client;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.TestHost;
	using Microsoft.Extensions.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Xunit;
	using static JWT.Controllers.TokenController;

    /// <summary>
    ///
    /// Drone API Integration tests
    ///
    /// MANUAL UPDATES REQUIRED!
    ///
    /// NOTE: In order to run an pass these scaffolded tests they have to be manually adjusted 
    ///       according to new entity class properties - search for MANUAL UPDATES REQUIRED!
    ///
    /// </summary>
    [Collection("HttpClient collection")]
    public class DroneTest : BaseTest
    {
	    public HttpClientFixture fixture;

	    public DroneTest(HttpClientFixture fixture)
	    {
		    this.fixture = fixture;
		    var client = fixture.Client;
	    }

	    public static string LastAddedDrone { get; set; }

	    #region Drone tests

	    [Fact]
	    public async Task drone_getall()
	    {
		    var httpclient = fixture.Client;
		    if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
		    //
		    var util = new UtilityExt();
		    //MANUAL UPDATES REQUIRED!
		    //todo - add if any parent of the entity
		    //add entity
		    var droneid = await util.addDrone(httpclient);
		    //
		    httpclient.DefaultRequestHeaders.Authorization =
			    new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
		    var response = await httpclient.GetAsync("/api/drone");
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		    var jsonString = await response.Content.ReadAsStringAsync();
		    var vmenititys =
			    (ICollection<UserViewModel>) JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(jsonString);
		    Assert.True(vmenititys.Count > 0);
		    // lazy-loading test if entity has children
		    response = await httpclient.GetAsync("/api/drone/" + droneid.ToString());
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		    jsonString = await response.Content.ReadAsStringAsync();
		    var vmenitity = JsonConvert.DeserializeObject<DroneViewModel>(jsonString);
		    //Assert.True(vmenitity.Kids.Count == 1);
		    //clean
		    await util.removeDrone(httpclient, droneid);
		    //remove if any parent entity added 
	    }


	    [Fact]
	    public async Task drone_add_update_delete()
	    {
		    var httpclient = fixture.Client;
		    ;
		    if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
		    
		    DroneViewModel drone = new DroneViewModel
		    {
			    UserId = 1,
			    CompanyAccountId = 1,
			    Name = "drone test 1",
			    Token = "tt1223334444tt",
			    StatusCode = DroneStatusCode.Maintenance,
			    TestText = "tt test"
		    };

		    httpclient.DefaultRequestHeaders.Authorization =
			    new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
		    var response = await httpclient.PostAsync("/api/drone", new StringContent(
			    JsonConvert.SerializeObject(drone), Encoding.UTF8, "application/json"));
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.Created, response.StatusCode);
		    var lastAddedId = await response.Content.ReadAsStringAsync();
		    Assert.True(int.Parse(lastAddedId) > 1);
		    int id = 0;
		    int.TryParse(lastAddedId, out id);

		    //get inserted
		    var util = new UtilityExt();
		    var vmentity = await util.GetDrone(httpclient, id);

		    //update test
		    vmentity.TestText = "tt updated";
		    response = await httpclient.PutAsync("/api/drone/" + id.ToString(),
			    new StringContent(JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

		    //confirm update
		    response = await httpclient.GetAsync("/api/drone/" + id.ToString());
		    response.EnsureSuccessStatusCode();
		    var jsonString = await response.Content.ReadAsStringAsync();
		    var oj = JObject.Parse(jsonString);
		    var tt = oj["testText"].ToString();
		    Assert.Equal(tt, vmentity.TestText);

		    //another update with same account - concurrency
		    vmentity.TestText = "tt updated 2";
		    response = await httpclient.PutAsync("/api/drone/" + id.ToString(),
			    new StringContent(JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
		    Assert.Equal(HttpStatusCode.PreconditionFailed, response.StatusCode);

		    //delete test 
		    response = await httpclient.DeleteAsync("/api/drone/" + id.ToString());
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
	    }

	    [Fact]
	    public async Task drone_getbyid()
	    {
		    var httpclient = fixture.Client;
		    if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
		    //
		    var util = new UtilityExt();
		    //MANUAL UPDATES REQUIRED!
		    //todo - add parent of the entity if exist
		    //add entity
		    var droneid = await util.addDrone(httpclient);
		    //
		    httpclient.DefaultRequestHeaders.Authorization =
			    new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
		    var response = await httpclient.GetAsync("/api/drone/" + droneid.ToString());
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		    var jsonString = await response.Content.ReadAsStringAsync();
		    var vmenitity = JsonConvert.DeserializeObject<DroneViewModel>(jsonString);
		    Assert.True(vmenitity.TestText == "tt updated");

		    //clean
		    await util.removeDrone(httpclient, droneid);
		    //remove if any parent entity added 
	    }

	    #endregion

	    #region Drone async tests

	    [Fact]
	    public async Task drone_getallasync()
	    {
		    var httpclient = fixture.Client;
		    if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
		    //
		    var util = new UtilityExt();
		    //MANUAL UPDATES REQUIRED!
		    //todo - add parent of the entity if exist
		    //add entity
		    var droneid = await util.addDrone(httpclient);
		    //
		    httpclient.DefaultRequestHeaders.Authorization =
			    new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
		    var response = await httpclient.GetAsync("/api/droneasync");
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		    var jsonString = await response.Content.ReadAsStringAsync();
		    var vmenititys =
			    (ICollection<UserViewModel>) JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(jsonString);
		    Assert.True(vmenititys.Count > 0);
		    // lazy-loading test if entity has children
		    response = await httpclient.GetAsync("/api/droneasync/" + droneid.ToString());
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		    jsonString = await response.Content.ReadAsStringAsync();
		    var vmenitity = JsonConvert.DeserializeObject<DroneViewModel>(jsonString);
		    //Assert.True(vmenitity.Kids.Count == 1);
		    //clean
		    await util.removeDrone(httpclient, droneid);
		    //remove if any parent entity added 
	    }


	    [Fact]
	    public async Task drone_add_update_delete_async()
	    {
		    var httpclient = fixture.Client;
		    ;
		    if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
		    //
		    DroneViewModel drone = new DroneViewModel
		    {
			    //MANUAL UPDATES REQUIRED!
			    //initiate viewmodel object
			    TestText = "tt updated"
		    };

		    httpclient.DefaultRequestHeaders.Authorization =
			    new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
		    var response = await httpclient.PostAsync("/api/droneasync", new StringContent(
			    JsonConvert.SerializeObject(drone), Encoding.UTF8, "application/json"));
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.Created, response.StatusCode);
		    var lastAddedId = await response.Content.ReadAsStringAsync();
		    Assert.True(int.Parse(lastAddedId) > 1);
		    int id = 0;
		    int.TryParse(lastAddedId, out id);

		    //get inserted
		    var util = new UtilityExt();
		    var vmentity = await util.GetDrone(httpclient, id);

		    //update test
		    vmentity.TestText = "tt updated";
		    response = await httpclient.PutAsync("/api/droneasync/" + id.ToString(),
			    new StringContent(JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);

		    //confirm update
		    response = await httpclient.GetAsync("/api/droneasync/" + id.ToString());
		    response.EnsureSuccessStatusCode();
		    var jsonString = await response.Content.ReadAsStringAsync();
		    var oj = JObject.Parse(jsonString);
		    var tt = oj["testText"].ToString();
		    Assert.Equal(tt, vmentity.TestText);

		    //another update with same account - concurrency
		    vmentity.TestText = "tt updated 2";
		    response = await httpclient.PutAsync("/api/droneasync/" + id.ToString(),
			    new StringContent(JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
		    Assert.Equal(HttpStatusCode.PreconditionFailed, response.StatusCode);

		    //delete test 
		    response = await httpclient.DeleteAsync("/api/droneasync/" + id.ToString());
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

	    }

	    [Fact]
	    public async Task drone_getbyidasync()
	    {

		    var httpclient = fixture.Client;
		    if (String.IsNullOrEmpty(TokenTest.TokenValue)) await TokenTest.token_get(httpclient);
		    //
		    var util = new UtilityExt();
		    //MANUAL UPDATES REQUIRED!
		    //todo - add if any parent of the entity
		    //add entity
		    var droneid = await util.addDrone(httpclient);
		    //
		    httpclient.DefaultRequestHeaders.Authorization =
			    new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
		    var response = await httpclient.GetAsync("/api/droneasync/" + droneid.ToString());
		    response.EnsureSuccessStatusCode();
		    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		    var jsonString = await response.Content.ReadAsStringAsync();
		    var vmenitity = JsonConvert.DeserializeObject<DroneViewModel>(jsonString);
		    Assert.True(vmenitity.TestText == "tt updated");

		    //clean
		    await util.removeDrone(httpclient, droneid);
		    //remove if any parent entity added 
	    }

	    #endregion
    }

    public partial class UtilityExt
    {
	    public async Task<int> addDrone(HttpClient client)
	    {

		    DroneViewModel vmentity = new DroneViewModel
		    {
			    UserId = 1,
			    CompanyAccountId = 1,
			    Name = "drone test 1",
			    Token = "tt1223334444tt",
			    StatusCode = DroneStatusCode.Maintenance,
			    TestText = "tt updated"
		    };

		    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
		    var response = await client.PostAsync("/api/drone", new StringContent(
			    JsonConvert.SerializeObject(vmentity), Encoding.UTF8, "application/json"));
		    var jsonString = await response.Content.ReadAsStringAsync();
		    int lastAdded = 0;
		    int.TryParse(jsonString, out lastAdded);
		    return lastAdded;
	    }

	    public async Task<DroneViewModel> GetDrone(HttpClient client, int id)
	    {
		    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenTest.TokenValue);
		    var response = await client.GetAsync("/api/droneasync/" + id.ToString());
		    response.EnsureSuccessStatusCode();
		    var jsonString = await response.Content.ReadAsStringAsync();
		    var vmentity = JsonConvert.DeserializeObject<DroneViewModel>(jsonString);
		    return vmentity;
	    }

	    public async Task removeDrone(HttpClient client, int id)
	    {
		    await client.DeleteAsync("/api/drone/" + id.ToString());
	    }
    }
}