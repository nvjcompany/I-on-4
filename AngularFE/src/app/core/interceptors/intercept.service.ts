import { Injectable } from '@angular/core';
import {
    HttpEvent, 
    HttpInterceptor, 
    HttpHandler, 
    HttpRequest,
    HttpResponse
  } from '@angular/common/http'
import { Observable } from 'rxjs';
import { catchError,tap} from 'rxjs/operators';

@Injectable()
export class InterceptService implements HttpInterceptor
{
    intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>>
    {
        const URL = 'https://localhost:44336/api/'
        request = request.clone({
            setHeaders: {
                Authorization: `Bearer ${localStorage.getItem('AUTH_TOKEN')}`
            },
            url: URL + request.url
        });

        return next.handle(request)
        .pipe(tap (event => {
            if(event instanceof HttpResponse)
            {
                //console.log("everything is fine")
                //console.log(event)
            }
        },
            error => {
                //console.log(error)
            }
        ))
    }
}