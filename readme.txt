יצירת NotificationHub עם מתודה SendNotification
יצירת INotificationClient עם מתודה GetNotification
שתיהן צריכות להחזיר Task!!

להגדיר בStartup  services.AddSignalR();
להגדיר בStartup endpoint לnotificationHub

להוסיף NotificationService שיהיה BackgroundService
יקבל IHubContext<NotificationHub, INotificationClient>
וישלח הודעה כל כמה שניות


צד לקוח
להתקין חבילה @aspnet/signalr
להוסיף service
ng g service NotificationService

להעתיק קוד
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


בApp.Component.ts להוסיף את הconnect והaddNotificationListener

ng g component send-notification --module app
<button (click)="sendMessage()">Send Message</button>
ליצור מתודה שתשלח הודעה