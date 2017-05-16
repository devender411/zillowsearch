using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using PropertyModels;
namespace test.Controllers
{
	public class PropertyResultsController : Controller
    {
		[HttpPost]
        public async Task<IActionResult> Search(string street,string city,string state)
        {
			//get searchresults ();
			var model = await GetAPIResultsAsync(street, city, state);
			return View(model);
        }
		private async Task<List<PropertySet>> GetAPIResultsAsync(string street, string city, string state)
		{
			List<PropertySet> results = new List<PropertySet>();

			var res = new PropertySet();
			//X1-ZWz1dyb53fdhjf_6jziz
			string url = "http://www.zillow.com/webservice/GetSearchResults.htm?";
			string zwsid = "zws-id=X1-ZWz1dyb53fdhjf_6jziz";
			string parameters = "&address=" + street + "&citystatezip=" + city + "%2C+" + state;// + "+" + zip;
			string apiUrl = "http://www.zillow.com/webservice/GetSearchResults.htm?zws-id=X1-ZWz1dyb53fdhjf_6jziz&address=2114+Bigelow+Ave&citystatezip=Seattle%2C+WA";
			apiUrl = url + zwsid + parameters;
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiUrl);
				client.DefaultRequestHeaders.Accept.Clear();

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();
					XmlDocument xmlresults = new XmlDocument();
					TextReader tr = new StringReader(data);
					XDocument xdoc = XDocument.Load(tr);

					foreach (XElement element in xdoc.Descendants("result"))
					{
						int i = 1;
						var list = (from x in element.Element("address").Elements()
								   select new
								   {
									   Name = x.Name,
									   Value = (string)x
								   }).ToList();
						Address add = new Address();
						foreach (var elem in list)
						{
							
							switch (elem.Name.ToString())
							{
								case "street":
									add.Street = elem.Value;
									break;

								case "zipcode":
									add.zipcode = elem.Value;
									break;
									
								case "city":
									add.City = elem.Value;
									break;
								case "state":
									add.State = elem.Value;
									break;
								case "latitude":
									add.latitude = elem.Value;
									break;
								case "longitude":
									add.longitude = elem.Value;
									break;

							}
							res.address = add;

						}
					}
					
				}


			}
			results.Add(res);

			return results;
		}
	}
}