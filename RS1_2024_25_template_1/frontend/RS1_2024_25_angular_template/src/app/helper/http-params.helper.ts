import {HttpParams} from '@angular/common/http';

export function buildHttpParams(requestObject: any): HttpParams {
  let params = new HttpParams();

  Object.entries(requestObject).forEach(([key, value]) => {
    if (value !== undefined && value !== null) {
      params = params.set(key, value.toString());
    }
  });

  return params;
}
