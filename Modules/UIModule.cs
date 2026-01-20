using IntegrationApp.Models;
namespace IntegrationApp.Modules;
// Интерфейс пользователя
public class UIModule
{
    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("--=== Учёт заявок на техническое обслуживаниее ===--");
        Console.WriteLine("1. Добавить новаую заявку");
        Console.WriteLine("2. Вывести список заявок");
        Console.WriteLine("3. Изменить статус заявки");
        Console.WriteLine("4. Выход из списка заявок");
        Console.Write("\nВыберите действие: ");
    }
    public Request CreateRequest(int nextId)
    {
        Console.Clear();
        Console.WriteLine("=== Добавить новую заявку ===\n");
        Console.Write("Клиент: ");
        string client = Console.ReadLine()!;
        Console.Write("Наименование устройства: ");
        string device = Console.ReadLine()!;
        Console.Write("Проблема: ");
        string problem = Console.ReadLine()!;

            var request = new Request(
                nextId,
                client,
                device,
                problem,
                Status.New,
                DateTime.Now
            );

        Console.WriteLine("\n✓ Заявка создана и добавлена!");
        Console.ReadKey();
        return request;
    }
    public void ShowRequests(List<Request> requests)
    {
        Console.Clear();
        Console.WriteLine($"=== Вывести список заявок ===\n");
        Console.WriteLine($"Всего: {requests.Count}\n");

        if (requests.Count == 0)
            {
                Console.WriteLine("Заявок нет.");
            }
        else
        {
            foreach (var r in requests)
                {
                Console.WriteLine($"[{r.Id}] {r.Client} - {r.Device}");
                Console.WriteLine($"   Проблема заявки: {r.Problem}");
                Console.WriteLine($"   Статус заявки: {GetStatusText(r.Status)}");
                Console.WriteLine($"   Дата: {r.Created:dd.MM.yyyy HH:mm}");
                Console.WriteLine();
                }
        }
        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
    }
    public void UpdateRequestStatus(List<Request> requests)
    {
        Console.Clear();
                Console.WriteLine("=== Изменение статуса заявки===\n");

        if (requests.Count == 0)
        {
            Console.WriteLine("Нет заявок для изменения.");
                 Console.ReadKey();
            return;
        }

        Console.Write("Номер заявки: ");

        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0 || id > requests.Count)
        {
            Console.WriteLine("Неверный номер заявки!");
                    Console.ReadKey();
            return;
        }

        Console.WriteLine("\nВыберите новый статус:");
        Console.WriteLine("1. Новая");
        Console.WriteLine("2. В работе");
        Console.WriteLine("3. Выполнена");
        Console.Write("Ваш выбор: ");

        if (!int.TryParse(Console.ReadLine(), out int statusChoice) || statusChoice < 1 || statusChoice > 3)
        {
            Console.WriteLine("Неверный выбор статуса!");
                    Console.ReadKey();
            return;
        }
            var request = requests[id - 1];
            requests[id - 1] = request with { Status = (Status)(statusChoice - 1) }; // Находим заявку и обновляем статус
            Console.WriteLine($"\n✓ Статус заявки №{id} изменён на: {GetStatusText((Status)(statusChoice - 1))}");
                    Console.ReadKey();
    }
    private string GetStatusText(Status status)
    {
        return status switch
        {
            Status.New => "Новая",
            Status.InProgress => "В работе",
            Status.Completed => "Выполнена",
            _ => "Неизвестно"
        };
    }
}
