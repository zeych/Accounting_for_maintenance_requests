namespace IntegrationApp.Models;
//модель данных
public enum Status { New, InProgress, Completed }
public record Request(
    int Id,
    string Client,
    string Device,
    string Problem,
    Status Status,
    DateTime Created
);