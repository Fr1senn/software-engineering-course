export interface IIntegralService {
    integrateTrapezoidal(f: (x: number) => number, a: number, b: number, epsilon: number): number;
}