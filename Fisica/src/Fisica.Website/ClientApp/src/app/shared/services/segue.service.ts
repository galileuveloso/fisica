import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AbstractHttpService } from './abstract-http.service';

@Injectable({
  providedIn: 'root'
})
export class SegueService extends AbstractHttpService {

  constructor(@Inject('BASE_URL') baseUrl: string, httpClient: HttpClient) {
    super(baseUrl, httpClient, 'api/segue');
  }

  public seguirProfessor(professorId: number): Observable<void> {
    return this.post('seguir', { ProfessorId: professorId });
  }

  public deixarDeSeguirProfessor(professorId: number): Observable<void> {
    return this.delete(`deixar-de-seguir/${professorId}`);
  }
}
