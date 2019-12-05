import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private hubConnection: HubConnection;

  public async connect() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl("/notificationHub")
      .configureLogging(LogLevel.Information)
      .build();

    await this.hubConnection.start();
  }

  public async addNotificationListener() {
    let premission = await Notification.requestPermission();

    if (premission == "granted") {
      this.hubConnection.on('GetNotification', (data) => {
        var notification = new Notification("Title", { body: data });
      });
    }
  }

  public sendNotification(message: string) {
    this.hubConnection.send("SendNotification", message);
  }
}
