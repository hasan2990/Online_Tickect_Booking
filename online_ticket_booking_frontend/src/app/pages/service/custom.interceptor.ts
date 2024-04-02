import { HttpInterceptorFn } from '@angular/common/http';

export const customInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenObject = JSON.parse(localStorage.getItem('angular17token') || '{}');
  const myToken = tokenObject.accessToken;
  console.log(myToken);
  
  const cloneRequest=req.clone({
    setHeaders:{
      Authorization: `Bearer ${myToken}`
    }
  });
  return next(cloneRequest);
};

// -----------Here implement refresh token ---------------
// import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
// import { catchError, throwError } from 'rxjs';
// import { AuthService } from './auth.service';
// import { inject } from '@angular/core';

// export const customInterceptor: HttpInterceptorFn = (req, next) => {
  
//   const authSrv = inject(AuthService);

//   const tokenObject = JSON.parse(localStorage.getItem('angular17token') || '{}');
//   const myToken = tokenObject.accessToken;
//   console.log(myToken);
  
//   const cloneRequest=req.clone({
//     setHeaders:{
//       Authorization: `Bearer ${myToken}`
//     }
//   });
//   return next(cloneRequest).pipe(
//   catchError((error: HttpErrorResponse) => {
//     debugger;
//     if(error.status === 401){
//       const isRefreshToken = confirm("Your Session is Expired. Do you want to Continue");
//       if(isRefreshToken){
//         authSrv.$refreshToken.next(true);
//       }
//     }
//     return throwError(error);
//   })
//   );
// };

