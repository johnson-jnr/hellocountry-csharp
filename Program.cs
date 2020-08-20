using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Headers;

namespace HelloCountry
{

  public class Program
  {

    private static readonly HttpClient client = new HttpClient();
    public static async Task Main()
    {

      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

      try
      {
        string[] fields = { "name", "capital", "languages", "currencies", "population" };

        //Get all Countries
        List<Country> countries = await getAllCountries();
        Console.WriteLine(JsonConvert.SerializeObject(countries));

        //Search by Country Code
        //string code = "col";
        //Country country = await searchCountryCode(code);
        //Console.WriteLine(JsonConvert.SerializeObject(country));


        //Search by Country Codes
        //string[] codes = { "col", "no", "ee" };
        //List<Country> countries = await searchCountryCodes(codes, fields);
        //Console.WriteLine(JsonConvert.SerializeObject(countries));

        //Search by Country Name
        //string countryName = "niger";
        //List<Country> countries = await searchCountryName(countryName, false, fields);
        //Console.WriteLine(JsonConvert.SerializeObject(countries));

        //Search by Currency Code
        //string code = "cop";
        //List<Country> countries = await searchCountryCurrency(code);
        //Console.WriteLine(JsonConvert.SerializeObject(countries));

        //Search by Language Code
        //string langCode = "es";
        //List<Country> countries = await searchCountryLanguage(langCode);
        //Console.WriteLine(JsonConvert.SerializeObject(countries));

        //Search by capital
        //string capital = "nairobi";
        //List<Country> countries = await searchCountryCapital(capital);
        //Console.WriteLine(JsonConvert.SerializeObject(countries));

        //Search by call code
        //string callCode = "57";
        // List<Country> countries = await searchCountryCallCode(callCode);
        //Console.WriteLine(JsonConvert.SerializeObject(countries));

        //Search by region
        //string region = "africa";
        //List<Country> countries = await searchCountryRegion(region);
        //Console.WriteLine(JsonConvert.SerializeObject(countries));

        //Search by regional blocs
        //string regional = "eu";
        //List<Country> countries = await searchCountryRegionalBloc(regional, fields);
        //Console.WriteLine(JsonConvert.SerializeObject(countries));

        Console.WriteLine("Done Fetching data");

      }

      catch (Exception e)
      {
        Console.WriteLine("Exception Caught!");
        Console.WriteLine(e.Message);
      }
    }

    static async Task<List<Country>> getAllCountries(params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/all";

      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static async Task<List<Country>> searchCountryName(string name, bool fullText = false, params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/name/" + name;

      var query = new Dictionary<string, string>()
        {
            { "fullText", fullText.ToString() }
        };

      if (fields.Length > 0)
      {
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static async Task<Country> searchCountryCode(string code, params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/alpha/" + code;

      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      Country country = JsonConvert.DeserializeObject<Country>(response);
      return country;
    }

    static async Task<List<Country>> searchCountryCodes(string[] codes, params string[] fields)
    {
      string codeQuery = string.Join(';', codes);
      string url = "https://restcountries.eu/rest/v2/alpha?codes=" + codeQuery;

      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static async Task<List<Country>> searchCountryCurrency(string currencyCode, params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/currency/" + currencyCode;


      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static async Task<List<Country>> searchCountryLanguage(string langCode, params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/lang/" + langCode;


      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static async Task<List<Country>> searchCountryCapital(string capital, params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/capital/" + capital;


      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static async Task<List<Country>> searchCountryCallCode(string callCode, params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/callingcode/" + callCode;

      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static async Task<List<Country>> searchCountryRegion(string region, params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/region/" + region;

      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static async Task<List<Country>> searchCountryRegionalBloc(string regional, params string[] fields)
    {
      string url = "https://restcountries.eu/rest/v2/regionalbloc/" + regional;

      if (fields.Length > 0)
      {
        var query = new Dictionary<string, string>();
        query = addQueryFields(query, fields);
        url = QueryHelpers.AddQueryString(url, query);
      }
      Console.WriteLine(url);
      string response = await client.GetStringAsync(url);
      Console.WriteLine(response);
      List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response);
      return countries;
    }

    static Dictionary<string, string> addQueryFields(Dictionary<string, string> query, string[] fields)
    {
      string fieldsString = string.Join(';', fields);
      query.Add("fields", fieldsString);
      return query;
    }
  }
  public class Currency
  {
    public string code { get; set; }
    public string name { get; set; }
    public string symbol { get; set; }
  }

  public class Language
  {
    public string iso639_1 { get; set; }
    public string iso639_2 { get; set; }
    public string name { get; set; }
    public string nativeName { get; set; }
  }

  public class Translations
  {
    public string de { get; set; }
    public string es { get; set; }
    public string fr { get; set; }
    public string ja { get; set; }
    public string it { get; set; }
    public string br { get; set; }
    public string pt { get; set; }
    public string nl { get; set; }
    public string hr { get; set; }
    public string fa { get; set; }
  }

  public class RegionalBloc
  {
    public string acronym { get; set; }
    public string name { get; set; }
    public List<string> otherAcronyms { get; set; }
    public List<string> otherNames { get; set; }
  }

  public class Country
  {
    public string name { get; set; }
    public List<string> topLevelDomain { get; set; }
    public string alpha2Code { get; set; }
    public string alpha3Code { get; set; }
    public List<string> callingCodes { get; set; }
    public string capital { get; set; }
    public List<string> altSpellings { get; set; }
    public string region { get; set; }
    public string subregion { get; set; }
    public int population { get; set; }
    public List<double> latlng { get; set; }
    public string demonym { get; set; }
    public double? area { get; set; }
    public double? gini { get; set; }
    public List<string> timezones { get; set; }
    public List<string> borders { get; set; }
    public string nativeName { get; set; }
    public string numericCode { get; set; }
    public List<Currency> currencies { get; set; }
    public List<Language> languages { get; set; }
    public Translations translations { get; set; }
    public string flag { get; set; }
    public List<RegionalBloc> regionalBlocs { get; set; }
    public string cioc { get; set; }

  }
}