import { Component, OnInit } from '@angular/core';
import { EventoDataService } from '../_data-service/eventos.data-service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
    eventos: any[] = [];

  constructor(private eventoDataService: EventoDataService) { }

    ngOnInit() {
        this.get();
  }
    get() {
        this.eventoDataService.get().subscribe((data:any[]) => {
            this.eventos = data;
        }, error => {
            console.log(error);
            alert('error interno do sistema');
        })
    }
}
