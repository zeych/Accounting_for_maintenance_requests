using IntegrationApp.Modules;
namespace IntegrationApp;
class Program
{
    static void Main()
    {
        var storage = new StorageModule();
        var ui = new UIModule();
        var requests = storage.Load();   // Загружаем данные

        while (true)
        {
            ui.ShowMenu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var newRequest = ui.CreateRequest(requests.Count + 1);
                    requests.Add(newRequest);
                    break;
                case "2":
                    ui.ShowRequests(requests);
                    break;
                case "3":
                    ui.UpdateRequestStatus(requests);
                    break;
                case "4":
                    storage.Save(requests);
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}