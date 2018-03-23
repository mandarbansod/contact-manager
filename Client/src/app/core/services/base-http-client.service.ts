import { environment } from './../../../environments/environment.prod';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BaseHttpClientService {
    constructor(private httpClient: HttpClient) {
    }

    public get<T>(url: string): Observable<T> {
        return this.httpClient.get<T>(url)
            .catch(this.handleError);
    }

    public post<T>(url: string, data: T): Observable<boolean> {
        return this.httpClient.post(url, data).catch(this.handleError);
    }

    public put<T>(url: string, data: T): Observable<boolean> {
        return this.httpClient.put(url, data).catch(this.handleError);
    }

    public patch<T>(url: string, data: T) {
        return this.httpClient.patch(url, data);
    }

    public delete(url: string): Observable<boolean> {
        return this.httpClient.delete(url).catch(this.handleError);
    }


    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof Error) {
            console.log('An error occurred:', error.error.message);
            // this.coreServices.loggingService.error(error, error.error.message);
        } else {
            // write code to handle the invalid responses
        }
        return Observable.throw(error);
    }
}
