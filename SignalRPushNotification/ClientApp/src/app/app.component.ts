import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { SignalrService } from './services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';

  constructor(public signalr: SignalrService) { }

  ngOnInit() {
    this.signalr.connect();
    this.signalr.addNotificationListener();
  }
}
