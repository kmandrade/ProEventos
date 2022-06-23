import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class EventoDataService {
    module: string = '/api/evento';
    constructor(private http: HttpClient) { }


    get() {
        return this.http.get(this.module);
    }
}
