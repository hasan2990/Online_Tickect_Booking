import { HttpInterceptorFn } from '@angular/common/http';

export const customInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenObject = JSON.parse(localStorage.getItem('angular17token') || '{}');
  const myToken = tokenObject.token;
  const cloneRequest=req.clone({
    setHeaders:{
      Authorization: `Bearer ${myToken}`
    }
  });
  return next(cloneRequest);
};
