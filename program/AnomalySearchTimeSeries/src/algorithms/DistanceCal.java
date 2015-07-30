/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

import common.Utils;
import entity.NTimeSeries;
import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author Khanh Vy
 */
public class DistanceCal {

    private static double euclid(double[] a, double[] b) {
        assert (a.length == b.length);
        double ret = 0.0;
        for (int i = 0; i < a.length; i++) {
            double tmp = (a[i] - b[i]) * (a[i] - b[i]);
            ret += tmp;
        }
        return Math.sqrt(ret);
    }

    private static double[] homothetic(double[] data, int length) { // length must be smaller than or equal to data.length
        double[] ret = new double[length];
        double y_max = Utils.max(data);
        double y_min = Utils.min(data);
        double x_center = (double) (data.length / 2);
        double y_center = (y_max + y_min) / 2.0;
        double ratio = (length * 1.0) / (data.length * 1.0);
        double[] newData = new double[data.length];
        double[] newIndex = new double[data.length];
        for (int i = 0; i < data.length; i++) {
            double y = ratio * (data[i] - y_center) + y_center;
            newData[i] = y;
            double x = ratio * (i - x_center) + x_center;
            newIndex[i] = x;
        }
        List<Double> candidate = new ArrayList<Double>();
        int pivot = 0;
        for (int i = 0; i < data.length; i++) {
            if (i == 0) {
                candidate.add(newData[i]);
            } else if (Math.abs(newIndex[i] - newIndex[pivot]) >= ratio) {
                candidate.add(newData[i]);
                pivot = i;
            }
        }
        int cl = candidate.size();
        for (int i = 0; i < length; i++) {
            if (i < cl) {
                ret[i] = candidate.get(i);
            }else{
                ret[i] = newData[pivot]; // never
            }
        }
        return ret;
    }
//    private static double[] homothetic(double[] data, int length) { // length must be smaller than or equal to data.length
//        double[] ret = new double[length];
//        double y_max = Utils.max(data);
//        double y_min = Utils.min(data);
//        double x_center = (double) (data.length / 2);
//        double y_center = (y_max + y_min) / 2.0;
//        double ratio = (length * 1.0) / (data.length * 1.0);
//        double[] newData = new double[data.length];
//        for(int i = 0; i < data.length; i++){
//            double y = ratio * (data[i] - y_center) + y_center;
//            newData[i] = y;
//        }
//        int begin = (data.length - length) / 2;
//        for(int i = begin; i < begin + length; i++){
//            ret[i-begin] = newData[i]; 
//        }
//        return ret;
//    }
//    public static void main(String[] args) {
//        Scanner scanner = null;
//        try {
//            // Location of file to read
//            File file = new File("data.txt");
//            scanner = new Scanner(file);
//            int i = 0;
//            NTimeSeries series = new NTimeSeries();
//            while (scanner.hasNextLine()) {
//                i++;
//                String line = scanner.nextLine();
//                if (i == 1) {
//                    double e1 = Double.parseDouble(line);
//                } else if (i == 2) {
//                    double e2 = Double.parseDouble(line);
//                } else {
//                    series.addData(Double.parseDouble(line));
//                }
//            }
//            double[] d = new double[series.getData().size()];
//            for(int j = 0; j < series.getData().size(); j++){
//                d[j] = series.getData().get(j);
//            }
//            double[] s = homothetic(d, 30);
//            for(double a : s){
//                System.out.println(a);
//            }
//            scanner.close();
//        } catch (Exception ex) {
//            ex.printStackTrace(System.out);
//        } finally {
//            if (scanner != null) {
//                scanner.close();
//            }
//        }
//    }
}
