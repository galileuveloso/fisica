import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { map, Observable } from "rxjs";

type Parametter = string | number | boolean | Array<string | number | boolean>;

export abstract class AbstractHttpService {

  private readonly APPLICATION_JSON = 'application/json';
  private apiUrl: string;
  //protected sessionStorage: Ng2Storage = new Ng2Storage(sessionStorage);
  //protected cookieStorage: CookieStorage = new CookieStorage();

  constructor(baseUrl: string, private http: HttpClient, private initialPath?: string) {
    this.apiUrl = baseUrl;
  }

  /**
   *
   *
   * @protected
   * @param {Parametter} param
   * @param {string} [responseType=this.APPLICATION_JSON_UTF_8]
   * @returns {Observable<T>}
   * @memberof AbstractHttpService
   */
  protected findBy<T>(param: Parametter, responseType: string = this.APPLICATION_JSON): Observable<T> {
    const paramStr = param instanceof Array ? param.join('/') : param;
    return this.http.get(`${this.buildUrl()}/${paramStr}`, this.createOptions(null, null, responseType))
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  /**
   * Utilizar método buscarComQueryParam, quando não tiver certeza que todos os parametros do serviço serão informados e
   * queira que os mesmos sejão capturados como null no backend.
   * OBS.: No QueryParam utilizar nomeação por posição, ou seja, 0 para o primeiro e assim em diante.
   * @param path
   * @param pathParam
   */
  protected findWithQueryParam<T>(path: string, ...pathParam: Array<any>): Observable<T> {
    const parametros: { [index: string]: any } = {};

    if (!(pathParam === null || pathParam === undefined)) {
      let c: number = 0;
      pathParam.forEach(param => {
        const label: string = c.toString();
        parametros[label] = param;
        c++;
      });
    }

    return this.http.get(`${this.buildUrl(path)}`, this.createOptions(parametros))
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  protected get<T>(path?: string, params?: Object, responseType: string = this.APPLICATION_JSON): Observable<T> {
    return this.http.get(`${this.buildUrl(path)}`, this.createOptions(params, null, responseType))
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  protected post<T>(path?: string, body?: any, params?: Object, responseType: string = this.APPLICATION_JSON): Observable<T> {
    return this.http.post(`${this.buildUrl(path)}`, body, this.createOptions(params, body, responseType))
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  protected send<T>(path?: string, body?: any): Observable<T> {
    return this.http.post(`${this.buildUrl(path)}`, body)
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  protected put<T>(path?: string, body?: any, params?: Object, responseType: string = this.APPLICATION_JSON): Observable<T> {
    return this.http.put(`${this.buildUrl(path)}`, body, this.createOptions(params, body, responseType))
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  protected delete<T>(path?: string, body?: any, params?: Object, responseType: string = this.APPLICATION_JSON): Observable<T> {
    return this.http.delete(`${this.buildUrl(path)}`, this.createOptions(params, body, responseType))
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  protected head<T>(path?: string, body?: any, params?: Object, responseType: string = this.APPLICATION_JSON): Observable<T> {
    return this.http.head(`${this.buildUrl(path)}`, this.createOptions(params, body, responseType))
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  protected postLogout<T>(): Observable<T> {
    return this.http.post(`${this.buildUrl().replace('/api', '')}`, null, this.createOptions())
      .pipe(
        map((next) => this.handleResult<T>(next))
      );
  }

  dateTimeReviver = function (key: string, value: any) {
    var a;
    if (typeof value === 'string') {
      a = /(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})Z/.exec(value);
      if (a) {
        return new Date(a[0]);
      }
    }
    return value;
  }

  private handleResult<T>(result: any): T {
    let res: any = {};
    if (this.isJsonString(result)) {
      const dataRaw = JSON.parse(result, this.dateTimeReviver);
      if (dataRaw instanceof Array) {
        res = dataRaw.map(x => x as T);
      } else {
        res = JSON.parse(result, this.dateTimeReviver) as T;
      }
    } else if (!(result === null || result === undefined)) {
      res = result;
      //if (typeof result === 'string') {
      //  const resultFormatted = ['true', 'false'].any(x => x === result.toLocaleLowerCase()) ?
      //    Boolean(JSON.parse(result)) : result;
      //  res = resultFormatted;
      //} else if (typeof result === 'object') {
      //  res = result;
      //} else if (result instanceof Blob || typeof result === 'number' || typeof result === 'boolean') {
      //  res = result;
      //}
    }
    return res;
  }

  protected createOptions(parametters: any = null, body: any = null, responseType: string = this.APPLICATION_JSON): any {
    if (parametters) {
      let httpParams = new HttpParams();
      httpParams = this.buildParametters(parametters, httpParams);
      return {
        headers: this.buildHeaders(responseType),
        params: httpParams,
        body: body,
        responseType: responseType,
        reportProgress: false,
        withCredentials: true
      };
    } else {
      return {
        headers: this.buildHeaders(responseType),
        body: body,
        responseType: responseType,
        withCredentials: true
      };
    }
  }

  private buildParametters(arg: Object, httpParams: HttpParams): HttpParams {
    const entries = Object.entries(arg);
    entries.forEach(x => {
      if (!(x[1] === null || x[1] === undefined)) {
        if (typeof x[1] === 'object') {
          httpParams = this.buildParametters(x[1] as Object, httpParams);
        } else {
          httpParams = httpParams.set(x[0], x[1]);
        }
      }
    });
    return httpParams;
  }

  private buildHeaders(accept: string = this.APPLICATION_JSON): HttpHeaders {
    let auth = this.buildAuthorization();
    if (auth) {
      return new HttpHeaders({
        'Content-Type': this.APPLICATION_JSON,
        'accept': accept,
        'Authorization': auth
      });
    } else {
      return new HttpHeaders({
        'Content-Type': this.APPLICATION_JSON,
        'accept': accept
      });
    }
  }

  private buildAuthorization(): string {
    const token = localStorage.getItem('TOKEN');
    return token ? `Bearer ${token}` : '';
  }

  private buildUrl(path: string = ''): string {
    const initPath = this.initialPath ?? this.initialPath;
    path = !path ? '' : `/${path}`;
    return `${this.apiUrl}${initPath}${path}`;
  }

  private isJsonString(resposta: any): boolean {
    try {
      const formattedResponse = JSON.parse(resposta);
      if (formattedResponse && typeof formattedResponse === 'object') {
        return true;
      } else {
        return false;
      }
    } catch (e) {
      return false;
    }
  }

}

export enum ResponseType {
  TEXT = 'text/plain',
  JSON = 'application/json',
  BLOB = 'application/octet-stream',
  ARRAYBUFFER = 'arraybuffer',
  DOCUMENT = 'document',
  MS_STREAM = 'ms-stream'
}
