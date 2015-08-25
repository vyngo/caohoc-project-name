/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

/**
 *
 * @author Khanh Vy
 */
public class LinearRegression {
    
    public static double[] regress(double[] x, double[] y){
        assert (x.length == y.length);
        double[] ret = new double[3];
        double[][] A = new double[2][3];
        A[0][0] = getSize(x);
        A[0][1] = sumX(x);
        A[0][2] = sumX(y);
        
        A[1][0] = A[0][1];
        A[1][1] = sumX2(x);
        A[1][2] = sumXY(x,y);
        
        double[] b = GaussElimination.gauss(A);
        for(int i = 0; i < 2; i++){
            ret[i] = b[i];
        }
        double err = calculateError(b, x, y);
        ret[2] = err;
        return ret;
    }
    
    private static double calculateError(double[] b, double[] x, double[] y){
        double error = 0.0;
        for(int i = 0; i < x.length; i++){
            double tmp = (b[0] + b[1] * x[i]) - y[i];
            tmp = tmp * tmp;
            error += tmp;
        }
        return error;
    }
    
    private static double sumX(double[] x) {
        double ret = 0.0;
        for (int i = 0; i < x.length; i++) {
            ret += x[i];
        }
        return ret;
    }

    private static double sumX2(double[] x) {
        double ret = 0.0;
        for (int i = 0; i < x.length; i++) {
            ret += x[i] * x[i];
        }
        return ret;
    }


    private static double sumXY(double[] x, double[] y) {
        double ret = 0.0;
        for (int i = 0; i < y.length; i++) {
            ret += x[i] * y[i];
        }
        return ret;
    }

    private static int getSize(double[] x) {
        return x.length;
    }
    
//    public static void main(String[] args) {
//        double[] x = new double[10];
//        double[] y = new double[10];
//        x[0] = 1;
//        y[0] = 1;
//        
//        x[1] = 1;
//        y[1] = 2;
//        
//        x[2] = 2;
//        y[2] = 2;
//        
//        x[3] = 2;
//        y[3] = 3;
//        
//        x[4] = 2;
//        y[4] = 4;
//        
//        x[5] = 3;
//        y[5] = 4;
//        
//        x[6] = 3;
//        y[6] = 5;
//        
//        x[7] = 4;
//        y[7] = 5;
//        
//        x[8] = 5;
//        y[8] = 6;
//        
//        x[9] = 6;
//        y[9] = 7;
//        
//        double[] ret = regress(x, y);
//        for(int i = 0; i < ret.length; i++){
//            System.out.println(ret[i]);
//        }
//    }
}
