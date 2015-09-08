/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package algorithms;

import common.Utils;
import entity.NSubsequence;
import entity.NTimeSeries;
import java.util.ArrayList;
import java.util.List;

/**
 * segmentation time series using with linear regression
 *
 * @author Khanh Vy
 */
public class LinearSegmentation {

    public static List<NSubsequence> segmentation(NTimeSeries series, double e1) {
        List<NSubsequence> ret = new ArrayList<NSubsequence>();
        boolean halt = false;
        int start = 0;
        do {
            NSubsequence sequence = getASegment(start, series, e1);
            ret.add(sequence);
            int end = sequence.getEnd();
            if (end == (series.getNumberOfDataPoint() - 1)) {
                halt = true;
            } else {
                start = getNextStartIndex(sequence, series);
            }
        } while (!halt);
        return ret;
    }

    private static int getNextStartIndex(NSubsequence se, NTimeSeries series) {
        int end = se.getEnd();
        return end + 1;
    }

    private static NSubsequence getASegment(int start, NTimeSeries series, double e1) {
        NSubsequence ret = null;
        boolean halt = false;
        int l = 3;// initial length
        int s = start;
        do {
            int e = s + l - 1;
            if (e >= series.getNumberOfDataPoint() - 1) {
                ret = new NSubsequence(start, series.getNumberOfDataPoint() - 1);
                break;
            }
            List<Double> subList = series.getData().subList(s, e + 1);
            double[] y = Utils.listToArray(subList);
            double[] x = new double[l];
            for (int i = 0; i < l; i++) {
                x[i] = s + i;
            }
            double[] reg = LinearRegression.regress(x, y);
            if (reg[2] >= e1) {
                halt = true;
                ret = new NSubsequence(start, e - 1);
            } else {
                l += 1;
            }
        } while (!halt);
        return ret;
    }
}
