import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  images: string[];

  ngOnInit() {
    this.images = [
      '../assets/images/OnionArch.png',     
      '../assets/images/OnionArchExplanation.png',
      '../assets/images/CreditDbDiagram.png',
      '../assets/images/CodeMapOnionArch.png',
    ];
  }
}
