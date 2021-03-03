import { SharedService } from './../../shared.service';
import { Component, Input, OnInit } from '@angular/core';
import { isNull } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-show-prop',
  templateUrl: './show-prop.component.html',
  styleUrls: ['./show-prop.component.css']
})
export class ShowPropComponent implements OnInit {

  constructor(private service:SharedService) { }

  PropertyList:any = [];
  ngOnInit(): void {
    this.refreshProList();
  }

  addClick(item) {
    var property = {
      id:0,
      address:item.address,
      yearBuilt:item.yearBuilt,
      listPrice:item.listPrice,
      monthlyRent:item.monthlyRent,
      grossYield:item.grossYield   
    };

    if(confirm("Are you sure to insert?")) {
      this.service.addProperty(property).subscribe(res => {
        alert("The property was inserted correctly");
      });
    }
  }

  refreshProList() {
    this.service.getPropertyList().subscribe(data => {
      this.PropertyList = data;
    });
  }

}
