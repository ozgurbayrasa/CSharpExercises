using StarwarsPlanetStatsApi.Api;
using StarwarsPlanetStatsApi.HTTPClient;
using StarwarsPlanetStatsApi.PlanetsListConverter;
using StarwarsPlanetStatsApi.Statistics;
using StarwarsPlanetStatsApi.TablePrinter;
using StarwarsPlanetStatsApi.UserIO;


IHttpClient client = new HttpClientProvider("https://swapi.dev/");
IApiReader apiReader = new ApiReader(client);
ITablePrinter printer = new UniversalTablePrinter();
IUserIO userIO = new IOUserCommand();
IPlanetStatisticsAnalyzer analyzer = new PlanetsStatisticsAnalyzer(userIO);

StarwarsPlanetStatsApp app = new StarwarsPlanetStatsApp(analyzer, apiReader,printer, userIO);

await app.Run();


public class StarwarsPlanetStatsApp
{
    private readonly IPlanetStatisticsAnalyzer analyzer;
    private readonly IApiReader apiReader;
    private readonly ITablePrinter printer;
    private readonly IUserIO userIO;


    
    public StarwarsPlanetStatsApp(IPlanetStatisticsAnalyzer _analyzer, IApiReader _apiReader, ITablePrinter _printer, IUserIO _userIO)
    {
        analyzer = _analyzer;
        apiReader = _apiReader;
        printer = _printer;
        userIO = _userIO;
    }

    public async Task Run()
    {
        // Read data using API.
        string planetsData = await apiReader.Read("api/planets");

        // Use converter to converts Planets list to planetDTO list.
        var planetsList = PlanetsListConverter.ConvertToPlanetsList(planetsData);

        // Use printer to print planets in well-designed table.
        printer.Print(planetsList);

        // Dislapy info message.
        userIO.PrintInfoMessage();

        // Analyze planets list.
        analyzer.Analyze(planetsList);

    }
}



