import { Component, OnInit } from '@angular/core';
import { SignalrService } from '../services/signalr.service';

@Component({
  selector: 'app-send-notification',
  templateUrl: './send-notification.component.html',
  styleUrls: ['./send-notification.component.css']
})
export class SendNotificationComponent implements OnInit {

  constructor(public signalr: SignalrService) { }

  ngOnInit() {
  }

  sendMessage() {
    this.signalr.sendNotification("My name is noam");
  }

}
