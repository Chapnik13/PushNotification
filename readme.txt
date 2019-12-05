����� NotificationHub �� ����� SendNotification
����� INotificationClient �� ����� GetNotification
����� ������ ������ Task!!

������ �Startup  services.AddSignalR();
������ �Startup endpoint �notificationHub

������ NotificationService ����� BackgroundService
���� IHubContext<NotificationHub, INotificationClient>
����� ����� �� ��� �����


�� ����
������ ����� @aspnet/signalr
������ service
ng g service NotificationService

������ ���
export class NotificationService {

  private hubConnection: HubConnection;

  public async connect() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl("/notificationHub")
      .configureLogging(LogLevel.Information)
      .build();

    await this.hubConnection.start();
  }

  public addNotificationListener() {
    this.hubConnection.on('GetNotification', (data) => {
      Notification.requestPermission(function (premission) {
        var notification = new Notification("Title", { body: data });
      });
    });
  }

  public sendNotification(message: string) {
    this.hubConnection.send("SendNotification", message);
  }

}


�App.Component.ts ������ �� �connect ��addNotificationListener

ng g component send-notification --module app
<button (click)="sendMessage()">Send Message</button>
����� ����� ����� �����