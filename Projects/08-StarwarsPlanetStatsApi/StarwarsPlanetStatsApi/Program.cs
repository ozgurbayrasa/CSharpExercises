using StarwarsPlanetStatsApi.Api;
using StarwarsPlanetStatsApi.HTTPClient;
using StarwarsPlanetStatsApi.PlanetsListConverter;
using StarwarsPlanetStatsApi.TablePrinter;

IHttpClient httpClientProvider = new HttpClientProvider("https://swapi.dev/api/");
IApiReader apiReader = new ApiReader(httpClientProvider);
string planetsData = await apiReader.Read("planets");
var list = PlanetsListConverter.ConvertToPlanetsList(planetsData);

ITablePrinter printer = new UniversalTablePrinter();
printer.Print(list);
