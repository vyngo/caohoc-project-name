/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

/**
 *
 * @author Khanh Vy
 */
public class GaussElimination {

    public static void print(double[][] A) {
        int n = A.length; // row
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n + 1; j++) {
                System.out.print(A[i][j] + "\t");
                if (j == n - 1) {
                    System.out.print("| ");
                }
            }
            System.out.println();
        }
        System.out.println();
    }

    public static double[] gauss(double[][] A) {
        int n = A.length; //reow

        for (int i = 0; i < n; i++) {
            // Search for maximum in this column
            double maxEl = Math.abs(A[i][i]);
            int maxRow = i;
            for (int k = i + 1; k < n; k++) {
                if (Math.abs(A[k][i]) > maxEl) {
                    maxEl = Math.abs(A[k][i]);
                    maxRow = k;
                }
            }

            // Swap maximum row with current row (column by column)
            for (int k = i; k < n + 1; k++) {
                double tmp = A[maxRow][k];
                A[maxRow][k] = A[i][k];
                A[i][k] = tmp;
            }

            // Make all rows below this one 0 in current column
            for (int k = i + 1; k < n; k++) {
                double c = -A[k][i] / A[i][i];
                for (int j = i; j < n + 1; j++) {
                    if (i == j) {
                        A[k][j] = 0;
                    } else {
                        A[k][j] += c * A[i][j];
                    }
                }
            }
        }

        // Solve equation Ax=b for an upper triangular matrix A
        double[] x = new double[n];
        for (int i = n - 1; i >= 0; i--) {
            x[i] = A[i][n] / A[i][i];
            for (int k = i - 1; k >= 0; k--) {
                A[k][n] -= A[k][i] * x[i];
            }
        }
        return x;
    }
    
    public static void main(String[] args) {
        double[][] A = new double[3][4];
        A[0][0] = 7.0;
        A[0][1] = 19.0;
        A[0][2] = 65.0;
        A[0][3] = 61.70;
        
        A[1][0] = 19.0;
        A[1][1] = 65.0;
        A[1][2] = 253.0;
        A[1][3] = 211.04;
        
        A[2][0] = 65.0;
        A[2][1] = 253.0;
        A[2][2] = 1061.0;
        A[2][3] = 835.78;
        
        print(A);
        double[] x = gauss(A);
        System.out.println("Res: " + x);
    }
}
