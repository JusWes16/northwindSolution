import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-n',
  templateUrl: './counter-n.component.html',
  styleUrls: ['./counter-n.component.css']
})
export class CounterNComponent {
  public currentCount = 0;
  public displayMessage = false;
  public customIncrement = 0;

  public incrementCounter(customIncrem) {
    this.customIncrement = parseInt(customIncrem);
    this.displayMessage = true;
    this.currentCount += this.customIncrement;
  }

  //public getCustomIncrement(customIncrem) {
  //  this.customIncrement = parseInt(customIncrem);
  //  this.displayMessage = true;
  //}
}
