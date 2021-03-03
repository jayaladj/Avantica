import { SharedService } from './../../shared.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-show-prop-db',
  templateUrl: './show-prop-db.component.html',
  styleUrls: ['./show-prop-db.component.css']
})
export class ShowPropDbComponent implements OnInit {

  constructor(private service:SharedService) { }

  PropertyList:any = [];
  ngOnInit(): void {
    this.refreshProList();
  }

  deleteClick(item) {
    if(confirm("Are you sure to delete?")) {
      this.service.deleteProperty(item.id).subscribe(res => {
        alert("The property was deleted correctly");
        this.refreshProList();
      });
    }
  }

  refreshProList() {
    this.service.getPropertyListDB().subscribe(data => {
      this.PropertyList = data;
    });
  }

}
