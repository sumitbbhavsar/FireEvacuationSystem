import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: [ './app.component.css' ]
})
export class AppComponent implements OnInit  {
  name = 'Angular';
title = 'Block(10*10)';
type='BubbleChart';//Scatter
  data = [
      // ["Dipak", 8, 12],
      // ["Sumit", 4, 5.5],
      // ["Kumar Sanu", 11, 14],
      // ["Mayank", 3, 3.5],
      // ["Tushar", 6.5, 7],
      // ["Aksay", 6, 8],
      // ["Modi", 17, 18],
      // ["Test", -1, -18],
];

constructor(){
  // this.data = this.getCoordinateValue();
// setTimeout(this.getCoordinateValue(), 5000);
// this.timeout()
 this.getCoordinateValue();
}      

ngOnInit(){
      setInterval(() => this.getCoordinateValue(),2000);
  }

getCoordinateValue(){
     var array = [];
     this.data = [];
	//for each point, randomize a coordinate and push it into an array
	for (let i=0;i<=2;i++) {
		let x = Math.floor(Math.random()*5);
		let y = Math.floor(Math.random()*5);
		array.push([
      'Test'+i, x, y
    ]);
	}
  this.data = array;
   // console.log(this.data);
   }

//  timeout() {
//       var that = this;
//       setTimeout(function () {
//           console.log('Test');
//           // this.data = this.getCoordinateValue();
//            that.timeout();
//       }, 5000);
//   }

// columnNames = ['Browser', 'Percentage'];

columnNames = ['Name', 'EmpId','Signal Strength'];

// columnNames = ['Name',{'Id':'number'}, 'Weight'];

// options = {
//    colors: ['#e0440e', '#e6693e', '#ec8f6e', '#f3b49f', '#f6c7b6'], is3D: true, 
// };
  options = {
    vAxis: {viewWindow: {min: 0, max: 10}, format: "#", gridlines: {count: 10}},
    hAxis: {viewWindow: {min: 0, max: 10}, format: "#", gridlines: {count: 10}}
    
         };
   width = 1050;
   height = 800;
}
