import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WidgetAula } from '../models/widget.model';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class WidgetService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/widget');
  }

  public inserirAula(aulaId: number, widgetId: number): Observable<void> {
    return this.post('inserir-aula', { AulaId: aulaId, WidgetId: widgetId });
  }

  public excluirAula(widgetAulaId: number): Observable<void> {
    return this.delete(`inserir-aula/${widgetAulaId}`);
  }

  public selecionarWigetsAulas(): Observable<WidgetAula[]> {
    return this.get<WidgetAula[]>('selecionar-favoritos');
  }
}
