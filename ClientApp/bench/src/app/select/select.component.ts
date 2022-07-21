import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {Company} from 'src/app/models/company'
import { TickService } from '../tick.service';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';


@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',  
  styleUrls: ['./select.component.scss']
})
export class SelectComponent implements OnInit {

  constructor(private http: HttpClient, private tickService: TickService) { }

  companies: Company[];
  ngOnInit(): void {
    this.tickService.getCompanies()
    .subscribe(data => this.companies = data);
  }
}
