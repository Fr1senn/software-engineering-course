import { Injectable } from '@angular/core';
import { IIntegralService } from '../interfaces/IIntegralService';

@Injectable({
  providedIn: 'root'
})
export class IntegralService implements IIntegralService {

  public integrateTrapezoidal(func: (x: number) => number, a: number, b: number, epsilon: number = 0.01): number {
    let n = 1;
    let integralPrev = 0;
    let integralCurrent = 0;
    let h = b - a;

    do {
        integralPrev = integralCurrent;
        integralCurrent = 0;

        for (let i = 0; i < n; i++) {
            const leftEndpoint = a + i * h;
            const rightEndpoint = a + (i + 1) * h;
            integralCurrent += 0.5 * (rightEndpoint - leftEndpoint) * (func(leftEndpoint) + func(rightEndpoint));
        }

        h /= 2;
        n *= 2;
    } while (Math.abs(integralCurrent - integralPrev) > epsilon);

    return integralCurrent;
  }
}
