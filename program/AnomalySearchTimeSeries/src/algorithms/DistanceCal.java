/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

import common.Utils;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Khanh Vy
 */
public class DistanceCal {

    public static double distance(double[] a, double[] b) {
        if (a.length == b.length) {
            return euclid(a, b);
        } else if (a.length > b.length) {
            double[] tmp = homothetic(a, b.length);
            return euclid(b, tmp);
        }else {
            double[] tmp = homothetic(b, a.length);
            return euclid(a, tmp);
        }
    }

    private static double euclid(double[] a, double[] b) {
        assert (a.length == b.length);
        double ret = 0.0;
        double beta = 0.0;
        for(int i = 0; i < a.length; i++){
            beta += (b[i] - a[i]);
        }
        beta = beta / a.length;
        for (int i = 0; i < a.length; i++) {
            double tmp = (a[i] - b[i] - beta) * (a[i] - b[i] - beta);
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
        int centerIndex = (newData.length / 2);

        int num = 0;
        for (int i = centerIndex; i >= 0 && num < length / 2; i -= Double.valueOf(1 / ratio).intValue()) {
            candidate.add(0, newData[i]);
            num++;
        }
        num = 0;
        for (int i = centerIndex + Double.valueOf(1 / ratio).intValue(); i < newData.length && num < length / 2; i += Double.valueOf(1 / ratio).intValue()) {
            candidate.add(newData[i]);
            num++;
        }

        int cl = candidate.size();
        for (int i = 0; i < cl; i++) {
            ret[i] = candidate.get(i);
        }
        return ret;
    }
//    public static void main(String[] args) {
//        Scanner scanner = null;
//        try {
//            // Location of file to read
//            File file = new File("data.txt");
//            scanner = new Scanner(file);
//            int i = 0;
//            List<Double> series = new ArrayList<Double>();
//            while (scanner.hasNextLine()) {
//                i++;
//                String line = scanner.nextLine();
//                series.add(Double.parseDouble(line));
//            }
//            double[] d = new double[series.size()];
//            for(int j = 0; j < series.size(); j++){
//                d[j] = series.get(j);
//            }
//            double[] s = homothetic(d, 50);
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